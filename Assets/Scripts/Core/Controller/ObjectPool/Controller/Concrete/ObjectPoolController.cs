using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Core.Utilities.Results;
using UnityEngine;

public class ObjectPoolController : MonoBehaviour, IObjectPoolController
{
    public List<Pool> ObjectPools;
    
    public void InitializePools()
    {
        foreach (var pool in ObjectPools)
        {
            pool.Initialize();
        }
    }

    public DataResult<Pool> GetPool(PoolType poolType)
    {
        var result = ObjectPools.FirstOrDefault(p => p.PoolType == poolType);
        if (result != null)
            return new SuccessDataResult<Pool>(result);
        else
            return new ErrorDataResult<Pool>("Pool not exist");
    }
}


