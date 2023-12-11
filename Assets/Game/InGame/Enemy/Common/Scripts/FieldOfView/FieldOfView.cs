using System.Collections;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    // enemy config
    [SerializeField] private EnemyCommonConfig _enemyConfig;
    [SerializeField] private EnemyBaseInfo _enemyBaseInfo;
    [SerializeField] private LayerMask targetMask;
    [SerializeField] private LayerMask obstructionMask;

    // temp -> move to a config
    public GameObject playerRef;

    private bool canSeePlayer;
    public bool CanSeePlayer { get => canSeePlayer; }

    //public method get distance sight, angle sight
    public float DistanceSight { get => _enemyBaseInfo.DistanceSight; }
    public float AngleSight { get => _enemyBaseInfo.AngleSight; }


    private float lastTimeCheck;

    private void Start()
    {
        lastTimeCheck = float.MinValue;
    }

    private void Update()
    {
        // call function FieldOfView check
        if(Time.time > lastTimeCheck + _enemyConfig.WaitTimeCheckSight)
        {
            lastTimeCheck = Time.time;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, _enemyBaseInfo.DistanceSight, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < _enemyBaseInfo.AngleSight / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;
                    ConsoleLog.Log("Can see player");
                }
                else
                {
                    canSeePlayer = false;
                }
            }
            else
                canSeePlayer = false;
        }
        else if (canSeePlayer)
            canSeePlayer = false;
    }
}