using Animancer;
using System;
using UnityEngine;

public class ExplorerAnimationBase : MonoBehaviour
{
    [Space(12), Header("Component")]
    [SerializeField] private AnimancerComponent _animancer;

    [Space(12), Header("Animation Clips")]
    [SerializeField] private ClipTransition _idle;
    [SerializeField] private ClipTransition _run;
    [SerializeField] private ClipTransition _normalAttack;
    [SerializeField] private ClipTransition _skill;
    [SerializeField] private ClipTransition _death;

    public Action onDeath;

    protected virtual void OnEnable()
    {
        _normalAttack.Events.OnEnd = OnNormalAttackEnd;
        _run.Events.OnEnd = OnRunEnd;
        _skill.Events.OnEnd = OnRotateSkillEnd;
        _death.Events.OnEnd = OnDeathEnd;

        _animancer.Play(_idle);
    }


    #region ON ANIMATION END
    private void OnRotateSkillEnd()
    {
        _animancer.Play(_idle);
    }

    private void OnRunEnd()
    {
        _animancer.Play(_idle);
    }

    private void OnNormalAttackEnd()
    {
        _animancer.Play(_idle);
    }

    private void OnDeathEnd()
    {
        onDeath?.Invoke();
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
        _animancer.Stop();
        _animancer.Play(_normalAttack);
    }

    public void PlayRotateSkill()
    {
        _animancer.Play(_skill);
    }

    public void PlayDeath(Action onDeath)
    {
        this.onDeath = onDeath;
        _animancer.Stop();
        _animancer.Play(_death);
    }
    #endregion


    private void OnDestroy()
    {
        onDeath = null;
    }
}
