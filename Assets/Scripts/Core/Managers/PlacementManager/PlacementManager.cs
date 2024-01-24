using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlacementController))]
public class PlacementManager : Singleton<PlacementManager>
{
    public PlacementController PlacementController { get; private set; }

    private void Awake()
    {
        PlacementController = GetComponent<PlacementController>();
    }
}
