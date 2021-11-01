using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopCarAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("PoliceSiren");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
