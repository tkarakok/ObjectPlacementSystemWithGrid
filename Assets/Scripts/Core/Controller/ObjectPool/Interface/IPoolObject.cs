using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolObject
{
    public void OnGetPool();
    public void ResetObject();
    public void DestroyObject();
    
}
