using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SaveController))]
public class SaveManager : Singleton<SaveManager>
{
    public SaveController SaveController { get; private set; }

    private void Awake()
    {
        SaveController = GetComponent<SaveController>();
    }
}
