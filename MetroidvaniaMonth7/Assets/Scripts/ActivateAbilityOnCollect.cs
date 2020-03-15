using UnityEngine;

public class ActivateAbilityOnCollect : CollectBase
{
    [SerializeField]
    GameObject ability;
    [SerializeField]
    AbilitySaveSystem abilitySave;
    [SerializeField]
    int index = 0;
    SpriteRenderer render;

    void Start()
    {
        if(ability == null)
        {
            render = GetComponentInChildren<SpriteRenderer>();
            Debug.Log("Warning! No Ability is Assigned to this Collectable!");
        }
        else
        {
            if(abilitySave.activeAbilities[index] == true)
            {
                gameObject.SetActive(false);
            }
        }
    }

    protected override void HandleCollection()
    {
        base.HandleCollection();
        ability.SetActive(true);
        abilitySave.activeAbilities[index] = true;
        if(render != null)
        {
            render.enabled = false;
        }
    }
}
