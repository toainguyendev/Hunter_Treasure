using Animancer;
using System;
using UnityEngine;

public class EnemyAnimationControllerBase : MonoBehaviour
{
    [Space(12), Header("Component")]
    [SerializeField] private AnimancerComponent _animancer;
    [SerializeField] private EnemyStateManagement _enemyStateManagement;

    [Space(12), Header("Animation Clips")]
    [SerializeField] private ClipTransition _idle;
    [SerializeField] private ClipTransition _run;
    [SerializeField] private ClipTransition _normalAttack;
    [SerializeField] private ClipTransition _dead;

    public Action OnDoneAttack;
    public Action OnDoneDead;


    protected virtual void OnEnable()
    {
        _normalAttack.Events.OnEnd = OnNormalAttackEnd;
        _run.Events.OnEnd = OnRunEnd;
        _dead.Events.OnEnd = OnDeadEnd;

        _animancer.Play(_idle);
    }

    private void OnDeadEnd()
    {
        ConsoleLog.Log("On dead end");
        OnDoneDead?.Invoke();
    }


    #region ON ANIMATION END
    private void OnRunEnd()
    {
        if(_enemyStateManagement.IsDead)
        {
            return;
        }

        _animancer.Play(_idle);
    }

    private void OnNormalAttackEnd()
    {
        if (_enemyStateManagement.IsDead)
        {
            return;
        }

        _animancer.Play(_idle);
        OnDoneAttack?.Invoke();
    }
    #endregion


    #region TRIGGER ANIMATION
    public void StopAnimation()
    {
        _animancer.Stop();
    }

    public void PlayIdle()
    {
        _animancer.Play(_idle);
    }

    public void PlayRun()
    {
        _animancer.Play(_run);
    }

    public void PlayNormalAttack()
    {
        ConsoleLog.Log("Play normal attack");
        _animancer.Play(_normalAttack);
    }

    public void PlayDead(Action onDead = null)
    {
        OnDoneDead = onDead;
        _animancer.Play(_dead);
    }
    #endregion
}
