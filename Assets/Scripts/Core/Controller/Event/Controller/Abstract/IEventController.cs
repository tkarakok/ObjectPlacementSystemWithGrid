using System;
using System.Collections;
using System.Collections.Generic;
using Core.Utilities.Results;
using UnityEngine;

public interface IEventController : IControllerBase
{
    public DataResult<T> GetEvent<T>() where T : IEvent, new();
}
