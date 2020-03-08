using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WriterBase : MonoBehaviour, IWriteDialog
{
    [SerializeField]
    protected List<string> dialogLines;
    public List<string> DialogLines => dialogLines;

    public abstract void WriteDialog(string textLine);
}
