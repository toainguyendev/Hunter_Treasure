using Animancer;
using UnityEngine;

public class EnemyAnimationControllerBase : MonoBehaviour
{
    [Space(12), Header("Component")]
    [SerializeField] private AnimancerComponent _animancer;

    [Space(12), Header("Animation Clips")]
    [SerializeField] private ClipTransition _idle;
    [SerializeField] private ClipTransition _run;
    [SerializeField] private ClipTransition _normalAttack;

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
    #endregion
}
