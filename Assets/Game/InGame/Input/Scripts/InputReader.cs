using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private InputData _inputData;

    private void Update()
    {
        _inputData.Horizontal = Input.GetAxis("Horizontal");
        _inputData.Vertical = Input.GetAxis("Vertical");
        _inputData.Jump = Input.GetButtonDown("Jump");
    }
}
