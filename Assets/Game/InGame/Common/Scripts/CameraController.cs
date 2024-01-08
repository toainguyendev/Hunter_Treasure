using Cinemachine;
using UnityEngine;

public class CameraController : MonoSingleton<CameraController>
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    public void SetTarget(Transform target)
    {
        virtualCamera.Follow = target;
    }
}
