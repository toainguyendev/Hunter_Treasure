using UnityEngine;

public class NormalAttack : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private ExplorerBaseInfo _explorerBaseInfo;
    [SerializeField] private InputData _inputData;
    [SerializeField] private ExplorerAnimationBase _animationController;


    #region RUNTIME DATA
    private float coolDownAttack = 0;
    private bool isPerformAttack = false;
    #endregion


    #region GETTER AND SETTER
    public bool IsPerformAttack
    {
        get => isPerformAttack;
    }
    #endregion

    public void Attack()
    {
        if (coolDownAttack <= 0)
        {
            Vector3 castOrigin = _attackPoint.position;
            Collider[] hitColliders = Physics.OverlapSphere(castOrigin, _explorerBaseInfo.AttackRange);

            foreach (Collider collider in hitColliders)
            {
                if (collider.CompareTag("Enemy"))
                {
                    ConsoleLog.LogError("Hit enemy");
                    collider.GetComponent<EnemyHealthBase>().TakeDamage(_explorerBaseInfo.Attack);
                }
            }

            _animationController.PlayNormalAttack();

            coolDownAttack = _explorerBaseInfo.RateAttack;
            isPerformAttack = true;
        }
    }


    private void Awake()
    {
        coolDownAttack = float.MinValue;
    }

    private void Update()
    {
        coolDownAttack -= Time.deltaTime;

        if (coolDownAttack < 0)
        {
            coolDownAttack = -1;
            isPerformAttack = false;
        }
    }
}
