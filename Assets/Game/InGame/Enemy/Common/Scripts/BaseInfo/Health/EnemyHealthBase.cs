using UnityEngine;

public class EnemyHealthBase : MonoBehaviour, IHealth
{
    [SerializeField] private EnemyBaseInfo _enemyBaseInfo;
    [SerializeField] private EnemyHealthUIControll _enemyHealthUIControll;
    [SerializeField] private EnemyAnimationControllerBase _enemyAnimationControllerBase;
    [SerializeField] private EnemyStateManagement _enemyStateManagement;
    [SerializeField] private BaseCondition _conditionPass;

    private float _currentHP;
    public float CurrentHP
    {
        get => _currentHP; 
        set
        {
            _currentHP = value;
            if(_currentHP < 0)
            {
                _currentHP = 0;
            }
        }
    }

    private void Awake()
    {
        _currentHP = _enemyBaseInfo.HP;
        _enemyHealthUIControll.SetupHealth(_enemyBaseInfo.HP);
    }

    public void Heal(float healAmount)
    {
        _currentHP += healAmount;
        _currentHP = Mathf.Clamp(_currentHP, 0, _enemyBaseInfo.HP);
    }

    public void TakeDamage(float damage)
    {
        _currentHP -= damage;
        _currentHP = Mathf.Clamp(_currentHP, 0, _enemyBaseInfo.HP);
        ConsoleLog.Log($"{gameObject.name} take damage {damage}, current health: {CurrentHP}");

        _enemyHealthUIControll.UpdateUI(_currentHP);

        if(_currentHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _conditionPass.IsPassCondition = true;
        _enemyAnimationControllerBase.StopAnimation();
        _enemyStateManagement.IsDead = true;
        Destroy(gameObject);
        //_enemyAnimationControllerBase.PlayDead(() =>
        //{
        //    Destroy(gameObject);
        //});
    }
}
