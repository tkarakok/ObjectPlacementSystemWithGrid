using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveState 
{
    public int  Money { get; set; } 
    public void SetInitializeValues()
    {
        Money = 0;
    }
}
