using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemOnDeath : MonoBehaviour
{
    [SerializeField]
    GameObject objectToDrop;
    IHealth health;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<IHealth>();
        health.OnDie += HandleDie;
    }

    private void HandleDie()
    {
       if(Random.Range(0f,1.0f) >= 0.4)
        {
            Instantiate(objectToDrop, transform.position, Quaternion.identity);
        }
    }


}
