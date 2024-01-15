using UnityEngine;

public class EnemyNormalAttack : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private EnemyStateManagement enemyStateManagement;
    [SerializeField] private EnemyAnimationControllerBase enemyAnimationController;

    [Space(12), Header("Config")]
    [SerializeField] private CommonMapData commonMapData;
    [SerializeField] private EnemyBaseInfo enemyBaseInfo;


    private float countDownTimeAttack = 0f;

    private void Awake()
    {
        countDownTimeAttack = float.MinValue;

        enemyAnimationController.OnDoneAttack += () =>
        {
            enemyStateManagement.IsAttackingPlayer = false;
        };
    }


    private void Update()
    {
        if (!commonMapData.IsCompleteCreateExplorer || !commonMapData.IsDoneSetupMap || enemyStateManagement.IsDead)
            return;

        bool isPlayerInAttackRange = Vector3.Distance(transform.position, commonMapData.ExplorerTransform.position) <= enemyBaseInfo.AttackRange;

        if (isPlayerInAttackRange && countDownTimeAttack <= 0f)
        {
            enemyStateManagement.IsAttackingPlayer = true;
            enemyAnimationController.PlayNormalAttack();
            Attack();

            countDownTimeAttack = enemyBaseInfo.RateAttack;
        }

        countDownTimeAttack -= Time.deltaTime;
        if(countDownTimeAttack <= 0f)
        {
            countDownTimeAttack = -1f;
        }
    }

    private void Attack()
    {
        // get component player health and decrease health
        var playerHealth = commonMapData.ExplorerTransform.GetComponent<HealthBase>();
        playerHealth.TakeDamage(enemyBaseInfo.Attack);
    }
}
