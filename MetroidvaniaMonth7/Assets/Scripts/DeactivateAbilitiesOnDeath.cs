using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class as a whole is a bad idea. It being active is how we'll keep track of what the player has unlocked so far.
//maybe have an SO that keeps track of what's been unlocked? 
public class DeactivateAbilitiesOnDeath : MonoBehaviour
{
    IHealth health;
    AbilityUnlockManager containers;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponentInParent<IHealth>();
        health.OnDie += HandleDie;
        containers = GetComponent<AbilityUnlockManager>();
       
    }

    private void HandleDie()
    {
        foreach(GameObject ability in containers.abilityContainers)
        {
            ability.SetActive(false);
        }
    }
}
