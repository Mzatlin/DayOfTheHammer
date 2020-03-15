using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObjectsActiveOnEntry : MonoBehaviour
{
    [SerializeField]
    List<GameObject> itemsToSet = new List<GameObject>();
    IEntry entry;
    // Start is called before the first frame update
    void Start()
    {
        entry = GetComponent<IEntry>();
        entry.OnEnter += HandleEnter;
        entry.OnExit += HandleExit;
        Deactivate();
    }

    private void HandleExit()
    {
        Deactivate();
    }

    private void HandleEnter()
    {
        Reactivate();
    }

    void Deactivate()
    {
        foreach (GameObject obj in itemsToSet)
        {
            obj.SetActive(false);
        }
    }

    void Reactivate()
    {
        foreach (GameObject obj in itemsToSet)
        {
            obj.SetActive(true);
        }
    }

}
