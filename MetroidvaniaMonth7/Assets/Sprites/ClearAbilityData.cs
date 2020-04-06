using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearAbilityData : ClearDataBase
{
    [SerializeField]
    AbilitySaveSystem ability; 
    protected override void HandleClearData()
    {
        for (int i = 1; i < ability.activeAbilities.Count; i++)
        {
            ability.activeAbilities[i] = false;
        }
    }

}
