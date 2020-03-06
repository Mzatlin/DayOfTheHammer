using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWriteDialog 
{
    List<string> DialogLines { get; }
    void WriteDialog(string textLine);
}
