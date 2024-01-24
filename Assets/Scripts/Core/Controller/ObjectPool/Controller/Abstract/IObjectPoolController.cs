using System.Collections;
using System.Collections.Generic;
using Core.Utilities.Results;
using UnityEngine;

public interface IObjectPoolController : IControllerBase
{
    public void InitializePools();

    public DataResult<Pool> GetPool(PoolType poolType);
}
