using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject Player;
    public GameObject child;
    public float speed;

    private void Awake() 
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        child = Player.transform.Find("camera constraint").gameObject;

    }

    public void Update() {
        if (Input.GetKey(KeyCode.RightShift))
        {
            child = Player.transform.Find("camera constraint (reverse)").gameObject;
        }
        else 
        {
            child = Player.transform.Find("camera constraint").gameObject;
        }
    }

    private void FixedUpdate()
    {
        follow();
    }

    private void follow() 
    {
        gameObject.transform.position = Vector3.Lerp(transform.position, child.transform.position, Time.deltaTime * speed);
        gameObject.transform.LookAt(Player.gameObject.transform.position);
    }
}
