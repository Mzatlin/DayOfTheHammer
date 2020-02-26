using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAbilityOnCollect : CollectBase
{
    [SerializeField]
    GameObject ability;
    // Start is called before the first frame update
    void Start()
    {

    }

    protected override void HandleCollection()
    {
        base.HandleCollection();
        ability.SetActive(true);
        gameObject.SetActive(false);

    }
}
