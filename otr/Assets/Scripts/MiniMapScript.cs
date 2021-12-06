using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapScript : MonoBehaviour
{
    public Transform Player; 

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 MiniMapFollowPosition = Player.position; 
        MiniMapFollowPosition.y = transform.position.y;
        transform.position =  MiniMapFollowPosition; 
    }
}

//smega