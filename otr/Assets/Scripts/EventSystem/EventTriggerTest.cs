using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTriggerTest : MonoBehaviour
{
    /*
     * Example script for Triggering events. This script has to be attached to a game object.
     */
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            EventManager.TriggerEvent("test");
        }
    }
}
