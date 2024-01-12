using UnityEngine;

public class ExplorerActionController : MonoBehaviour
{
    [Space(12), Header("Data")]
    [SerializeField] private InputData _inputData;
    [SerializeField] private ExplorerBaseInfo _explorerBaseInfo;

    [Space(12), Header("Component")]
    [SerializeField] private ExplorerAnimationBase _animationController;
    [SerializeField] private NormalAttack _normalAttack;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private MoveBase _moveController;
    [SerializeField] private SkillBase _skillController;


    #region CALL BACK FUNCTION

    private void Update()
    {
        bool isPerformSkill = CheckSkill();

        // Check Normal Attack
        bool isAttacking = false;
        if (!isPerformSkill)
        {
            isAttacking = CheckNormalAttack();
        }

        // Move
        if (!isAttacking && !isPerformSkill)
        {
            Move();
        }
    }
    #endregion

    #region SKILL
    private bool CheckSkill()
    {
        if(_inputData.Skill)
        {
            _skillController.Trigger();
        }
        return _inputData.Skill || !_skillController.IsDonePerform;
    }
    #endregion

    #region NORMAL ATTACK
    private bool CheckNormalAttack()
    {
        if(_inputData.NormalAttack)
        {
            _normalAttack.Attack();
        }
        return _inputData.NormalAttack || _normalAttack.IsPerformAttack;
    }
    #endregion

    #region MOVE
    private void Move()
    {
        if (_inputData.Jump)
        {
            _moveController.Jump();
        }

        // Trigger 
        _moveController.Move();

        _moveController.RotateToMove();

        _moveController.ResetJumpInput();
    }
    #endregion
}
