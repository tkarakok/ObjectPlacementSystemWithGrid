using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    #region Base_Events

    public abstract class NoParamEvent : IEvent
    {
        private Action callback;
        private Dictionary<GameObject, Action> _subscriberHandlerDictionary = new Dictionary<GameObject, Action>();

        public virtual void AddListener(Action handler, GameObject subscriber = null)
        {
            if (subscriber == null) callback += handler;
            else
            {
                if (!_subscriberHandlerDictionary.ContainsKey(subscriber))
                {
                    _subscriberHandlerDictionary.Add(subscriber, handler);
                    callback += handler;
                }
            }
        }

        public void RemoveListener(Action handler, GameObject subscriber = null)
        {
            if (subscriber == null) callback -= handler;
            else
            {
                if (_subscriberHandlerDictionary.ContainsKey(subscriber))
                {
                    _subscriberHandlerDictionary.Remove(subscriber);
                    callback -= handler;
                }
            }
        }

        public void Execute()
        {
            var subscribersToRemove = _subscriberHandlerDictionary.Where(x => x.Key == null || !x.Key.activeInHierarchy)
                .ToArray();
            foreach (var subscriber in subscribersToRemove)
            {
                callback -= _subscriberHandlerDictionary[subscriber.Key];
                _subscriberHandlerDictionary.Remove(subscriber.Key);
            }

            callback?.Invoke();
        }
    }

    public abstract class EventWithOneParam<T1> : IEvent
    {
        private Action<T1> callback;

        public void AddListener(Action<T1> handler)
        {
            callback += handler;
        }

        public void RemoveListener(Action<T1> handler)
        {
            callback -= handler;
        }

        public void Execute(T1 arg1)
        {
            callback?.Invoke(arg1);
        }
    }

    public abstract class EventWithTwoParam<T1, T2> : IEvent
    {
        private Action<T1, T2> callback;

        public void AddListener(Action<T1, T2> handler)
        {
            callback += handler;
        }

        public void RemoveListener(Action<T1, T2> handler)
        {
            callback -= handler;
        }

        public void Execute(T1 arg1, T2 arg2)
        {
            callback?.Invoke(arg1, arg2);
        }
    }

    #endregion

}