using UnityEngine;

public class NormalAttack : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private ExplorerBaseInfo _explorerBaseInfo;
    [SerializeField] private InputData _inputData;


    private float coolDownAttack = 0;


    private void Awake()
    {
        coolDownAttack = float.MinValue;
    }

    private void Update()
    {
        coolDownAttack -= Time.deltaTime;

        if(_inputData.NormalAttack && coolDownAttack <= 0)
        {
            CheckHit();

            coolDownAttack = _explorerBaseInfo.RateAttack;
        }

        if(coolDownAttack <= 0)
        {
            coolDownAttack = 0;
        }
    }

    private void CheckHit()
    {
        Vector3 castOrigin = _attackPoint.position;
        Collider[] hitColliders = Physics.OverlapSphere(castOrigin, _explorerBaseInfo.AttackRange);

        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                ConsoleLog.Log($"Hit enemy with damage {_explorerBaseInfo.Attack}");
            }
        }
    }
}
