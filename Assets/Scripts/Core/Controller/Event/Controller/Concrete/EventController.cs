using System;
using System.Collections;
using System.Collections.Generic;
using Core.Utilities.Results;
using UnityEngine;

public class EventController : MonoBehaviour, IEventController
{
    private Dictionary<Type, IEvent> _events = new Dictionary<Type, IEvent>();

    public DataResult<T> GetEvent<T>() where T : IEvent, new()
    {
        Type eventType = typeof(T);
        IEvent eventToReturn;

        bool isEventExistInEventHub = _events.TryGetValue(eventType, out eventToReturn);

        if (isEventExistInEventHub)
        {
            return new SuccessDataResult<T>((T)eventToReturn);
        }
        else
        {
            return new ErrorDataResult<T>("Event not exist in system");
        }
    }

}
