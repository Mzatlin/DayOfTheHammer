using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAbilityOnUse : MonoBehaviour
{
    IAbility[] abilities;
    [SerializeField]
    PlayerStateSO playerState;
    // Start is called before the first frame update
    void Start()
    {
        abilities = GetComponents<IAbility>();
        foreach (IAbility obj in abilities)
        {
            obj.IsAbilityInUse = false;
            obj.OnAbilityEnd += HandleAbilityEnd;
            obj.OnAbilityStart += HandleAbilityBegin;
        }
    }



    private void HandleAbilityEnd()
    {
        playerState.isStopped = false;
    }

    private void HandleAbilityBegin()
    {
        playerState.isStopped = true;
    }

}

