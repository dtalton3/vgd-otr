using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetLightCollisionDetector : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //EnableRagdoll();
            rb.constraints = RigidbodyConstraints.None;
            Object.Destroy(gameObject, 5f);
        }
    }
}
