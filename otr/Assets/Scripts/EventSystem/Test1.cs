using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Test1 : MonoBehaviour
{
    /*
     * Example script for game object that has events that need to be called.
     */
    private UnityAction someListener;

    private void Awake()
    {
        someListener = new UnityAction(SomeFunction);
    }

    // listen
    private void OnEnable()
    {
        EventManager.StartListening("test", someListener);
        // can register a function without haveing to save it in UnityAction someListener
        EventManager.StartListening("test2", SomeOtherFunction);

    }

    // stop listening. This is needed to prevent memory leaks for clean up
    private void OnDisable()
    {
        EventManager.StopListening("test", someListener);
        // can deregister a function without have to save it into UnityAction someListener
        EventManager.StopListening("test2", SomeOtherFunction);
    }

    // fucntion for listener
    void SomeFunction()
    {
        Debug.Log("Some function was called!");
    }

    // another function for listener
    void SomeOtherFunction()
    {
        Debug.Log("Some other function was called");
    }
}
