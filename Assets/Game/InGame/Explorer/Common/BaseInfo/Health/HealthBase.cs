using SuperMaxim.Messaging;
using UnityEngine;

public class HealthBase : MonoBehaviour, IHealth
{
    [SerializeField] protected ExplorerBaseInfo explorerBaseInfo;
    [SerializeField] private RuntimeGlobalData runtimeGlobalData;

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

    private void Awake()
    {
        CurrentHP = explorerBaseInfo.HP;
    }

    public void Heal(float healAmount)
    {
        if(healAmount > 0)
        {
            _currentHP += healAmount;
            Messenger.Default.Publish(new ExplorerHealthPayload() { maxHP = explorerBaseInfo.HP, currentHP = CurrentHP });
        }
    }

    public void TakeDamage(float damage)
    {
        CurrentHP -= damage;

        Messenger.Default.Publish(new ExplorerHealthPayload() { maxHP = explorerBaseInfo.HP, currentHP = CurrentHP });

        if(CurrentHP <= 0)
        {
            Die();
            runtimeGlobalData.DataEndGame = new DataEndGame(false, runtimeGlobalData.DataStartGamePlay.LevelId, runtimeGlobalData.DataStartGamePlay.Explorer);
            ConsoleLog.Log("0" + runtimeGlobalData.GetInstanceID() + runtimeGlobalData.DataEndGame.IsWin);
            Messenger.Default.Publish(new EndGamePayload() { isWin = false });
        }
    }

    private void Die()
    {
        ConsoleLog.Log("Explorer Die");
    }
}
