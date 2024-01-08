using Animancer;
using System;
using UnityEngine;

public class EnemyAnimationControllerBase : MonoBehaviour
{
    [Space(12), Header("Component")]
    [SerializeField] private AnimancerComponent _animancer;

    [Space(12), Header("Animation Clips")]
    [SerializeField] private ClipTransition _idle;
    [SerializeField] private ClipTransition _run;
    [SerializeField] private ClipTransition _normalAttack;
    [SerializeField] private ClipTransition _dead;

    public Action OnDoneAttack;


    protected virtual void OnEnable()
    {
        _normalAttack.Events.OnEnd = OnNormalAttackEnd;
        _run.Events.OnEnd = OnRunEnd;

        _animancer.Play(_idle);
    }


    #region ON ANIMATION END
    private void OnRunEnd()
    {
        _animancer.Play(_idle);
    }

    private void OnNormalAttackEnd()
    {
        _animancer.Play(_idle);
        OnDoneAttack?.Invoke();
    }
    #endregion


    #region TRIGGER ANIMATION
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
        _animancer.Play(_normalAttack);
    }

    public void PlayDead(Action onDead = null)
    {
        _animancer.Play(_dead);
        _dead.Events.OnEnd = () => onDead?.Invoke();
    }
    #endregion
}
