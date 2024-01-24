using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UiController))]
public class UiManager : Singleton<UiManager>
{
    public UiController UiController { get; private set; }

    private void Awake()
    {
        UiController = GetComponent<UiController>();
    }
}


