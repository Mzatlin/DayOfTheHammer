using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AbilitySaveSystem")]
public class AbilitySaveSystem : ScriptableObject
{
    public List<bool> activeAbilities = new List<bool>();
    public Dictionary<string,GameObject> abilities = new Dictionary<string, GameObject>();
    
    public void ActivateAbility(int index)
    {
        activeAbilities[index] = true;
        //abilities[abilityName].SetActive(true);
    }

    public void ClearAbilitiesExceptFirst(string abilityName)
    {
        foreach(GameObject obj in abilities.Values)
        {
            obj.SetActive(false);
        }
        abilities[abilityName].SetActive(true);
    }
}
