using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    /* Event Manager Script for managing events.
     */
    // Dictionary for events
    private Dictionary <string, UnityEvent> eventDictionary;

    private static EventManager eventManager;

    // to allow game components to grab event manager easily
    public static EventManager instance
    {
        get
        {
            if (!eventManager)
            {
                eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                if (!eventManager)
                {
                    Debug.LogError("Thre needs to be one active EventManger script on a GameObject in your scene.");
                }
                else
                {
                    eventManager.Init(); 
                }
            }
            return eventManager;
        }
    }

    void Init()
    {
        if(eventDictionary == null)
        {
            eventDictionary = new Dictionary<string, UnityEvent>();
        }
    }

    // starts listening for events
    // event name is key for event in dictionary
    // listener is a funtion pointer
    // populates thisEvent if event is in dictionary else adds a new event and pushes it to dictionary
    public static void StartListening(string eventName, UnityAction listener)
    {
        UnityEvent thisEvent = null;

        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent)) 
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    // stops listening for events
    // eventName is the key for event in dictionary
    // listener is a function pointer
    // unregister event listener if it exists
    public static void StopListening(string eventName, UnityAction listener)
    {
        if (eventManager == null) return;
        UnityEvent thisEvent = null;
        if(instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    // trigger events
    public static void TriggerEvent(string eventName)
    {
        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            // calls all functions listening for event
            thisEvent.Invoke();
        }
    }
}
