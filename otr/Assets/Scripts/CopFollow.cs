using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CopFollow : MonoBehaviour
{
    private NavMeshAgent Cop;
    public GameObject respawnableCop;
    public GameObject Player;


    // Start is called before the first frame update
    void Start()
    {
        Cop = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);

        Vector3 dirToPlayer = transform.position - Player.transform.position;
        Vector3 newPos = transform.position - dirToPlayer;

        Cop.SetDestination(newPos);
    }
}
