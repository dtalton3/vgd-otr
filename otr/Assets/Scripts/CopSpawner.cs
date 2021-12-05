using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopSpawner : MonoBehaviour
{
    public GameObject respawnableCop;
    float timePassed;
    int copCount;
    
    private Vector3[] respawnPoints = {
            new Vector3(150f, 0f, 105f),
            new Vector3(150f, 0f, 205f),
            new Vector3(150f, 0f, 400f),
            new Vector3(150f, 0f, -100f),
            new Vector3(-150f, 0f, -100f),
            new Vector3(-150f, 0f, 100f),
            new Vector3(-150f, 0f, 205f),
            new Vector3(-150f, 0f, 400f)
        };
    // Start is called before the first frame update
    void Start()
    {
        timePassed = 0f;
        copCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        
        if(timePassed > 15f)
        {
            print("new cop car");
            timePassed = 0f;

            if (copCount < 12) {
                respawnCop();
                copCount++;
            }
        } 
    }

    void respawnCop()
    {
        int idx = 0;
        float smallestDistance = Vector3.Distance(respawnPoints[0], this.transform.position);
        float currentDistance;
        for (int i = 0; i < respawnPoints.Length; i++) {
            currentDistance = Vector3.Distance(respawnPoints[i], this.transform.position);
            if (currentDistance < smallestDistance) {
                smallestDistance = currentDistance;
                idx = i;
            }
        }
        print(this.transform.position);
        print(smallestDistance);
        print(idx);
        Instantiate(respawnableCop, respawnPoints[idx], new Quaternion(0f, 90f, 0f, 0f));
    }
}
