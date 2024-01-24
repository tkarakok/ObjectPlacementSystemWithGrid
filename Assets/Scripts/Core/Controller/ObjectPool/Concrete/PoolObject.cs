using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour, IPoolObject
{
    public bool IsAvailable { get; set; } = true;

    public void OnGetPool()
    {
        gameObject.SetActive(true);
        IsAvailable = false;
    }

    public void ResetObject()
    {
        IsAvailable = true;
    }

    public void DestroyObject()
    {
        DestroyObject(gameObject);
    }
}
