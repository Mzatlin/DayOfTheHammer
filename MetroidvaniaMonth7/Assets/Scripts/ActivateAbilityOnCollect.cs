using UnityEngine;

public class ActivateAbilityOnCollect : CollectBase
{
    [SerializeField]
    GameObject ability;

    void Start()
    {
        if(ability == null)
        {
            Debug.Log("Warning! No Ability is Assigned to this Collectable!");
        }
    }

    protected override void HandleCollection()
    {
        base.HandleCollection();
        ability.SetActive(true);
        gameObject.SetActive(false);
    }
}
