using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarController : MonoBehaviour
{
    public GameOverScript gos;
    private float startTime;
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float currSteerAngle;
    private float currBrakeForce; 
    private bool isBraking;

    //Collectible Variables
    public TextMeshProUGUI brackCountText;
    private int brackFound;

    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteeringAngle;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;

    private void Start()
    {

        startTime = Time.time;
        brackFound = 0;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
        if (brackFound >= 11)
        {
            Time.timeScale = 0f;
            gos.Setup(Time.time - startTime);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //print(collision.gameObject.name.Substring(0, 7));
        if (collision.gameObject.name.Substring(0, 7) == "Cop Car")
        {
            Time.timeScale = 0f;
            gos.Setup(Time.time - startTime);
        }
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        currBrakeForce = isBraking ? breakForce : 0f;
        ApplyBrakes();
    }

    private void HandleSteering() 
    {
        currSteerAngle = maxSteeringAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currSteerAngle;
        frontRightWheelCollider.steerAngle = currSteerAngle;
    }

    private void ApplyBrakes() 
    {
        frontLeftWheelCollider.brakeTorque = currBrakeForce; 
        frontRightWheelCollider.brakeTorque = currBrakeForce;
        rearLeftWheelCollider.brakeTorque = currBrakeForce;
        rearRightWheelCollider.brakeTorque = currBrakeForce;
    }

    private void GetInput() 
    {
        horizontalInput = Input.GetAxisRaw(HORIZONTAL);
        verticalInput = Input.GetAxisRaw(VERTICAL);
        isBraking = Input.GetKey(KeyCode.Space);
    }

    private void UpdateWheels() 
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Brack"))
        {
            other.gameObject.SetActive(false);
            brackFound++;
            brackCountText.text = "Brack: " + brackFound.ToString();
        }
    }
    
}
