using UnityEngine;

public class BaseCondition : MonoBehaviour
{
    protected bool _isPassCondition = false;

    public bool IsPassCondition
    {
        get => _isPassCondition; set => _isPassCondition = value;
    }
}
