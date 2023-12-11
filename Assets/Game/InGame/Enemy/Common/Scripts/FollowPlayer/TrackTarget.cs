using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrackTarget : MonoBehaviour
{
    // transform player to follow
    [SerializeField] private Transform playerTransform;
    [SerializeField] private NavMeshAgent navmeshAgent;


    private void Update()
    {
        navmeshAgent.SetDestination(playerTransform.position);
    }


}
