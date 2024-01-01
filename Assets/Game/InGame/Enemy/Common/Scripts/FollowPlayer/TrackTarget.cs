using UnityEngine;
using UnityEngine.AI;

public class TrackTarget : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navmeshAgent;

    [Space(12), Header("Components")]
    [SerializeField] private EnemyStateManagement enemyStateManagement;

    [Space(12), Header("Config")]
    [SerializeField] private EnemyCommonConfig enemyCommonConfig;

    [Space(12), Header("Data")]
    [SerializeField] private CommonMapData commonMapData;

    private Vector3 _originPos;
    private float _countDownTimeForgetPlayer = 0f;
    private void Awake()
    {
        _originPos = transform.position;
    }


    private void Update()
    {
        if (!commonMapData.IsCompleteCreateExplorer)
            return;

        if (enemyStateManagement.IsSeeingPlayer)
        {
            _countDownTimeForgetPlayer = enemyCommonConfig.TimeForgotPlayer;
            navmeshAgent.SetDestination(commonMapData.ExplorerTransform.position);
            navmeshAgent.angularSpeed = enemyCommonConfig.SpeedRotate;
        }
        else if(_countDownTimeForgetPlayer <= 0f)
        {
            navmeshAgent.SetDestination(_originPos);
        }
        _countDownTimeForgetPlayer -= Time.deltaTime;
    }
}
