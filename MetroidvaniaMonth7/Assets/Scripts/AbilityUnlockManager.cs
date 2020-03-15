using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityUnlockManager : MonoBehaviour
{
    [SerializeField]
    AbilitySaveSystem ability;

    public List<GameObject> abilityContainers = new List<GameObject>();
    Dictionary<string, GameObject> abilities = new Dictionary<string, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 1; i < abilityContainers.Count; i++)
        {
            abilityContainers[i].SetActive(ability.activeAbilities[i]);
        }
     //   foreach(GameObject obj in abilityContainers)
    //    {
    //        obj.SetActive(false);
    //    }
      //  abilityContainers[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
