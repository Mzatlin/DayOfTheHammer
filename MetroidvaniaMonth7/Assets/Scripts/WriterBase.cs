﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriterBase : MonoBehaviour, IWriteDialog
{
    [SerializeField]
    List<string> dialogLines;
    public List<string> DialogLines => dialogLines;

    public void WriteDialog(string textLine)
    {
        throw new System.NotImplementedException();
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}