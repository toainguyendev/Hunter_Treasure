using UnityEngine;
using UnityEngine.AI;

public class TrackTarget : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private NavMeshAgent navmeshAgent;

    [Space(12), Header("Components")]
    [SerializeField] private EnemyStateManagement enemyStateManagement;

    [Space(12), Header("Config")]
    [SerializeField] private EnemyCommonConfig enemyCommonConfig;

    private Vector3 _originPos;

    private void Awake()
    {
        _originPos = transform.position;
    }


    private void Update()
    {
        if(enemyStateManagement.IsSeeingPlayer)
        {
            navmeshAgent.SetDestination(playerTransform.position);
            navmeshAgent.angularSpeed = enemyCommonConfig.SpeedRotate;
        }
        else
        {
            navmeshAgent.SetDestination(_originPos);
        }
    }
}
