using System;
using UnityEngine;

public class EnemyHealthBase : MonoBehaviour, IHealth
{
    [SerializeField] private EnemyBaseInfo _enemyBaseInfo;
    [SerializeField] private EnemyHealthUIControll _enemyHealthUIControll;
    [SerializeField] private EnemyAnimationControllerBase _enemyAnimationControllerBase;

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

        _enemyHealthUIControll.UpdateUI(_currentHP);

        if(_currentHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _enemyAnimationControllerBase.PlayDead(() => Destroy(gameObject));
    }
}
