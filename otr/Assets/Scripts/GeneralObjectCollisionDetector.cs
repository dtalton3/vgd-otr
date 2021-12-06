using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralObjectCollisionDetector : MonoBehaviour
{
    public Rigidbody rb;
    private bool canPlaySound;
    private AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        canPlaySound = false;
        sound = GetComponent<AudioSource>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Cop"))
        {
            rb.constraints = RigidbodyConstraints.None;
            canPlaySound = true;
            Object.Destroy(gameObject, 5f);
        }

        if(canPlaySound)
        {
            sound.Play();
        }
        
    }
}
