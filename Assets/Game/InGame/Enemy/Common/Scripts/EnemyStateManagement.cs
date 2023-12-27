using System;
using UnityEngine;

public enum EnemyState
{
    Idle,
    Move,
    Attack,
    Dead
}

public class EnemyStateManagement : MonoBehaviour
{
    private EnemyState _enemyState;
    public EnemyState EnemyState => _enemyState;

    private Action<EnemyState> _onChangeState;

    public void AddOnChangeState(Action<EnemyState> action)
    {
        _onChangeState += action;
    }

    public void RemoveOnChangeState(Action<EnemyState> action)
    {
        _onChangeState -= action;
    }
}
