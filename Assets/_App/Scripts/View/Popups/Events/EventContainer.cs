using System.Collections.Generic;
using UnityEngine;

public abstract class EventContainer : ScriptableObject
{
    protected List<EventListener> _eventListeners = new List<EventListener>();

    public virtual void StartAction()
    {
        InvokeEvent();
    }
    
    public virtual void AddListener(EventListener eventListener)
    {
        _eventListeners.Add(eventListener);
    }
    
    public virtual void RemoveListener(EventListener eventListener)
    {
        _eventListeners.Remove(eventListener);
    }
    
    protected virtual void InvokeEvent()
    {

    }
}
