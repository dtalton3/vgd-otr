using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarAudio : MonoBehaviour
{
    public float minPitch = 0.15f;
    public float maxPitch = 1.75f;
    public float pitchMultiplier = 1.25f;
    public float pitchDivider = 15f;
    private float pitchFromCar;
    private string audioName = "CarEngine";
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        FindObjectOfType<AudioManager>().Play(audioName);
        FindObjectOfType<AudioManager>().SetPitch(audioName, minPitch);
    }

    private void FixedUpdate()
    {
        pitchFromCar = (rb.velocity.magnitude * pitchMultiplier) / pitchDivider;
        //Debug.Log("Pitch from car: " + pitchFromCar);
    }

    private void Update()
    {
        if (pitchFromCar < minPitch)
        {
            FindObjectOfType<AudioManager>().SetPitch(audioName, minPitch);
        }
        else if (pitchFromCar > maxPitch)
        {
            FindObjectOfType<AudioManager>().SetPitch(audioName, maxPitch);
        }
        else
        {
            FindObjectOfType<AudioManager>().SetPitch(audioName, pitchFromCar);
        }
    }
}
