using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // [SerializeField] private Vector3 offset;
    // [SerializeField] private Transform target;
    // [SerializeField] private float translateSpeed;
    // [SerializeField] private float rotationSpeed;

    // void FixedUpdate()
    // {
    //     HandleTranslation();
    //     HandleRotation();
    // }

    // private void HandleTranslation()
    // {
    //     var targetPosition = target.TransformPoint(offset);
    //     transform.position = Vector3.Lerp(transform.position, targetPosition, translateSpeed * Time.deltaTime);
    // }

    // private void HandleRotation()
    // {
    //     var direction = target.position - transform.position;
    //     var rotation = Quaternion.LookRotation(direction, Vector3.up);
    //     transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    // }

    public GameObject Player;
    public GameObject child;
    public float speed;

    private void Awake() 
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        child = Player.transform.Find("camera constraint").gameObject;

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
