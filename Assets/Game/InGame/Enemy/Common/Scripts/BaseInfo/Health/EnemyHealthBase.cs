using UnityEngine;

public class EnemyHealthBase : MonoBehaviour, IHealth
{
    // serialize field private enemybaseinfo
    [SerializeField] private EnemyBaseInfo _enemyBaseInfo;


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

    public void Heal(float healAmount)
    {
        _currentHP += healAmount;
        _currentHP = Mathf.Clamp(_currentHP, 0, _enemyBaseInfo.HP);
    }

    public void TakeDamage(float damage)
    {
        _currentHP -= damage;
        _currentHP = Mathf.Clamp(_currentHP, 0, _enemyBaseInfo.HP);
    }
}
