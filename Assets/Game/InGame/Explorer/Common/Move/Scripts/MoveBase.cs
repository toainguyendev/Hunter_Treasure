
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MoveBase : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] protected CharacterController _characterController;
    [SerializeField] protected ExplorerAnimationBase _animationController;


    [Space(12), Header("Data")]
    [SerializeField] protected InputData _inputData;
    [SerializeField] protected ExplorerBaseInfo explorerBaseInfo;


    private float yVelocity = 0;
    private bool hasJump = false;

    public virtual void Move()
    {
        if(_characterController.isGrounded && !hasJump)
        {
            yVelocity = -1;
        }
        else
        {
            yVelocity += Physics.gravity.y * Time.deltaTime;
        }

        Vector3 move = new Vector3(_inputData.Horizontal, yVelocity, _inputData.Vertical);
        _characterController.Move(move * explorerBaseInfo.MoveSpeed * Time.deltaTime);

        if(_inputData.Horizontal != 0 || _inputData.Vertical != 0)
        {
            _animationController.PlayRun();
        }
    }

    // Rotate player to direction of move
    public void RotateToMove()
    {
        if (_inputData.Horizontal != 0 || _inputData.Vertical != 0)
        {
            // rotate player to direction of move with Lerp function
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(_inputData.Horizontal, 0, _inputData.Vertical)), 0.1f);
        }
    }

    // Jump player
    public void Jump()
    {
        if (_characterController.isGrounded)
        {
            yVelocity = explorerBaseInfo.JumpVelocity;
            hasJump = true;
        }
    }

    public void ResetJumpInput()
    {
        if (hasJump)
        {
            _inputData.Jump = false;
            hasJump = false;
        }
    }
}
