using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTankAI : MonoBehaviour
{

    public Transform playerTank;
    public float moveSpeed = 5f;
    public float rotationSpeed = 2f;

    private NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = moveSpeed;
        navMeshAgent.angularSpeed = rotationSpeed * 100f;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTank != null)
        {
            navMeshAgent.SetDestination(playerTank.position);
        }
        //Vector3 directionToPlayer = (playerTank.position - transform.position).normalized;
        //transform.position += directionToPlayer * moveSpeed * Time.deltaTime;

        //Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
        //transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
    }
}
