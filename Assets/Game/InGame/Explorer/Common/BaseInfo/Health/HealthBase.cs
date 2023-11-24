using UnityEngine;

public class HealthBase : MonoBehaviour, IHealth
{
    [SerializeField] protected ExplorerBaseInfo explorerBaseInfo;

    // current health
    protected float _currentHP;


    public float CurrentHP
    {
        get => _currentHP; 
        set 
        {
            if(value < 0)
            {
                _currentHP = 0;
            }
            else if(value > explorerBaseInfo.HP)
            {
                _currentHP = explorerBaseInfo.HP;
            }
            else
            {
                _currentHP = value;
            }
        }
    }


    public void Heal(float healAmount)
    {
        if(healAmount > 0)
        {
            _currentHP += healAmount;
        }
    }

    public void TakeDamage(float damage)
    {
        CurrentHP -= damage;
    }
}
