using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(ObjectPoolController))]
public class ObjectPoolManager : Singleton<ObjectPoolManager>
{
    public ObjectPoolController ObjectPoolController { get; private set; }
    private void Awake()
    {
        ObjectPoolController = GetComponent<ObjectPoolController>();
    }

    private void Start()
    {
        ObjectPoolController.InitializePools();
    }
}
