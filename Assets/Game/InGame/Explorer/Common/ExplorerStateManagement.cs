using System;
using UnityEngine;

// enum state for Explorer
public enum ExplorerState
{
    Idle,
    Run,
    Jump,
    NormalAttack,
    Skill
}

public class ExplorerStateManagement : MonoBehaviour
{
    [SerializeField] private InputData _inputData;

    private ExplorerState _explorerState;
    public ExplorerState ExplorerState => _explorerState;

    public void SetState(ExplorerState state)
    {
        _explorerState = state;
    }

    #region RUNTIME DATA
    private bool isAttack = false;
    #endregion


    #region GETTER AND SETTER
    public bool IsAttack
    {
        get => isAttack;
        set => isAttack = value;
    }
    #endregion

    #region CALL BACK FUNCTION
    private void Awake()
    {
        _explorerState = ExplorerState.Idle;
    }

    private void Update()
    {
        switch (_explorerState)
        {
            case ExplorerState.Idle:
                break;
            case ExplorerState.Run:
                break;
            case ExplorerState.Jump:
                break;
            case ExplorerState.NormalAttack:
                _inputData.Horizontal = 0;
                _inputData.Vertical = 0;
                break;
            case ExplorerState.Skill:
                _inputData.Horizontal = 0;
                _inputData.Vertical = 0;
                break;
            default:
                break;
        }


        if (_inputData.NormalAttack || isAttack)
        {
            SetState(ExplorerState.NormalAttack);
        }
        else if (_inputData.Skill || isAttack)
        {
            SetState(ExplorerState.Skill);
        }
        else if (_inputData.Jump)
        {
            SetState(ExplorerState.Jump);
        }
        else if (_inputData.Horizontal != 0 || _inputData.Vertical != 0)
        {
            SetState(ExplorerState.Run);
        }
        else
        {
            SetState(ExplorerState.Idle);
        }
    }
    #endregion
}
