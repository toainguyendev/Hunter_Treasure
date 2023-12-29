using UnityEngine;

public class EnemyStateManagement : MonoBehaviour
{
    private bool _isSeeingPlayer;

    public bool IsSeeingPlayer
    {
        get => _isSeeingPlayer;
        set
        {
            _isSeeingPlayer = value;
        }
    }
}
