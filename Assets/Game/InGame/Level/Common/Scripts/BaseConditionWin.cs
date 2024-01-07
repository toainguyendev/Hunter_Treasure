using UnityEngine;

public class BaseConditionWin : MonoBehaviour
{
    protected bool _isPassCondition = false;

    public bool IsPassCondition
    {
        get => _isPassCondition; set => _isPassCondition = value;
    }
}
