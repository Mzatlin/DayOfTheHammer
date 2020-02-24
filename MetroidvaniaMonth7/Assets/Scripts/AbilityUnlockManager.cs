using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityUnlockManager : MonoBehaviour
{

    public List<GameObject> abilityContainers = new List<GameObject>();
    Dictionary<string, GameObject> abilities = new Dictionary<string, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject obj in abilityContainers)
        {
            obj.SetActive(false);
        }
        abilityContainers[3].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
