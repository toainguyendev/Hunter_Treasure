using Animancer;
using UnityEngine;

public class ExplorerAnimationBase : MonoBehaviour
{
    [Space(12), Header("Component")]
    [SerializeField] private ExplorerStateManagement _stateManagement;
    [SerializeField] private AnimancerComponent _animancer;

    [Space(12), Header("Animation Clips")]
    [SerializeField] private ClipTransition _idle;
    [SerializeField] private ClipTransition _run;
    [SerializeField] private ClipTransition _normalAttack;

    private void OnEnable()
    {
        _normalAttack.Events.OnEnd = OnNormalAttackEnd;
        _run.Events.OnEnd = OnRunEnd;

        _animancer.Play(_idle);
    }

    private void OnRunEnd()
    {
        _animancer.Play(_idle);
    }

    private void OnNormalAttackEnd()
    {
        _animancer.Play(_idle);
        _stateManagement.IsAttack = false;
    }

    private void Update()
    {
        if(_stateManagement.ExplorerState == ExplorerState.NormalAttack)
        {
            _animancer.Stop(_run);
            _animancer.Play(_normalAttack);
            _stateManagement.IsAttack = true;
        }

        if(_stateManagement.ExplorerState == ExplorerState.Run)
        {
            _animancer.Play(_run);
        }
    }
}
