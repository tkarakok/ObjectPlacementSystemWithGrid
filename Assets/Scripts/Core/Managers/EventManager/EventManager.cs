using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EventController))]
public class EventManager : Singleton<EventManager>
{
    private IEventController _eventController;
    public IEventController EventController => _eventController;

    private void Awake()
    {
        _eventController = GetComponent<IEventController>();
    }
}
