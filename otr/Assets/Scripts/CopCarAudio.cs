using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopCarAudio : MonoBehaviour
{

    private AudioSource[] sounds;

    private void Start()
    {
        sounds = GetComponents<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!collision.gameObject.CompareTag("Player"))
        {
            sounds[1].Play();
        }
    }
}
