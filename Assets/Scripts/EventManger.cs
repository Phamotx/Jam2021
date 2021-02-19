using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum Event
{
}
public class EventManger : MonoBehaviour
{
    private static EventManger eventManger;

    public static EventManger EventMangers
    {
        get
        {
            eventManger = FindObjectOfType<EventManger>() as EventManger;
            return eventManger;
        }
    }
    Dictionary<Event, List<Action<EventInfo>>> eventListeners;

    public void SubScribeEvent(Event eventName,Action<EventInfo> method)
    {
        if (eventListeners == null)
        {
            eventListeners = new Dictionary<Event, List<Action<EventInfo>>>();
        }
        if(!eventListeners.ContainsKey(eventName)|| eventListeners[eventName] == null)
        {
            eventListeners.Add(eventName, new List<Action<EventInfo>>());
            eventListeners[eventName].Add(method);
        }
        eventListeners[eventName].Remove(method);
        eventListeners[eventName].Add(method);
        Debug.Log("Event Get Scribed");
    }
    public void DeSubScribeEvent(Event eventName, Action<EventInfo> method)
    {
        if (!eventListeners.ContainsKey(eventName) || eventListeners[eventName] == null)
        {
            Debug.Log("Such Kind of Event does not exits");
            return;
        }
        eventListeners[eventName].Remove(method);
        Debug.Log("Event Get DeScribed");
    }

    public void TriggerEvent(Event eventName, EventInfo door)
    {
        if (!eventListeners.ContainsKey(eventName) || eventListeners[eventName] == null)
        {
            Debug.Log("Such Kind of Method does not exits on this event");
            return;
        }
        foreach (var el in eventListeners[eventName])
        {
            el(door);
        }
    }

    private void OnDestroy()
    {
        eventListeners.Clear();
        Debug.Log("All Event Get DeScribed");
    }
}
