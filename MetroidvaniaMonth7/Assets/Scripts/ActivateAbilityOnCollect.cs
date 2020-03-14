using UnityEngine;

public class ActivateAbilityOnCollect : CollectBase
{
    [SerializeField]
    GameObject ability;
    SpriteRenderer render;

    void Start()
    {
        if(ability == null)
        {
            render = GetComponentInChildren<SpriteRenderer>();
            Debug.Log("Warning! No Ability is Assigned to this Collectable!");
        }
    }

    protected override void HandleCollection()
    {
        base.HandleCollection();
        ability.SetActive(true);
        if(render != null)
        {
            render.enabled = false;
        }
    }
}
