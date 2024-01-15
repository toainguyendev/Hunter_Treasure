using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    // enemy config
    [SerializeField] private EnemyCommonConfig _enemyConfig;
    [SerializeField] private EnemyBaseInfo _enemyBaseInfo;
    [SerializeField] private LayerMask targetMask;
    [SerializeField] private LayerMask obstructionMask;

    [Space(12), Header("Components")]
    [SerializeField] private EnemyStateManagement enemyStateManagement;

    [Space(12), Header("Data")]
    [SerializeField] private CommonMapData commonMapData;

    private bool canSeePlayer;
    public bool CanSeePlayer { get => canSeePlayer; }

    //public method get distance sight, angle sight
    public float DistanceSight { get => _enemyBaseInfo.DistanceSight; }
    public float AngleSight { get => _enemyBaseInfo.AngleSight; }
    public Transform PlayerTransform { get => commonMapData.ExplorerTransform; }

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
        if(!commonMapData.IsDoneSetupMap || !commonMapData.IsCompleteCreateExplorer)
            return;

        Transform target = commonMapData.ExplorerTransform;

        Vector3 directionToTarget = (target.position - transform.position).normalized;

        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        if(distanceToTarget <= _enemyBaseInfo.DistanceSight)
        {
            if (Vector3.Angle(transform.forward, directionToTarget) < _enemyBaseInfo.AngleSight / 2)
            {
                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;
                    enemyStateManagement.IsSeeingPlayer = true;
                }
                else
                {
                    canSeePlayer = false;
                    enemyStateManagement.IsSeeingPlayer = false;
                }
            }
            else
            {
                canSeePlayer = false;
                enemyStateManagement.IsSeeingPlayer = false;
            }
        }
        else
        {
            canSeePlayer = false;
            enemyStateManagement.IsSeeingPlayer = false;
        }
        
    }
}