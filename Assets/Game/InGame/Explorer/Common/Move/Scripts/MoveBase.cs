
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MoveBase : MonoBehaviour
{
    // Character controller 
    [SerializeField] protected CharacterController _characterController;

    // Input data
    [SerializeField] protected InputData _inputData;

    // Base info
    [SerializeField] protected ExplorerBaseInfo explorerBaseInfo;


    private float yVelocity = 0;
    private bool hasJump = false;
    private void Update()
    {
        if (_inputData.Jump && _characterController.isGrounded)
        {
            Jump();
            hasJump = true;
        }

        // Move
        Move();

        // Rotate to move
        RotateToMove();

        if (hasJump)
        {
            _inputData.Jump = false;
            hasJump = false;
        }
    }

    protected virtual void Move()
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
    }

    // Rotate player to direction of move
    protected void RotateToMove()
    {
        if (_inputData.Horizontal != 0 || _inputData.Vertical != 0)
        {
            // rotate player to direction of move with Lerp function
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(_inputData.Horizontal, 0, _inputData.Vertical)), 0.1f);
        }
    }

    // Jump player
    protected void Jump()
    {
        yVelocity = explorerBaseInfo.JumpVelocity;
    }

}
