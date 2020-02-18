using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleAbilityUse : MonoBehaviour
{
    [SerializeField]
    AbilitySO ability;
    [SerializeField]
    GameObject abilitySource;
    // Start is called before the first frame update
    void Start()
    {
        Initialize(ability, abilitySource);
    }

    void Initialize(AbilitySO _ability, GameObject _abilitySource)
    {
        ability = _ability;
        ability.Initialize(_abilitySource);
    }

    // Update is called once per frame
    void Update()
    {
        ability.UseAbilityTick();
    }
}
