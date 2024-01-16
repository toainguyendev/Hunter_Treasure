using UnityEngine;

public class Treasure : MonoBehaviour
{
    [SerializeField] private BaseCondition _baseConditionWin;

    [Space(12)]
    [SerializeField] private BaseCondition[] _conditionsToCollect;


    private bool _isCollected;

    private bool CanCollect()
    {
        foreach (var condition in _conditionsToCollect)
        {
            if (!condition.IsPassCondition)
            {
                return false;
            }
        }
        return true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isCollected)
            return;

        if (CanCollect() && other.CompareTag("Player"))
        {
            // Do Animation
            ConsoleLog.Log("Treasure Collected");

            // set condition win
            _baseConditionWin.IsPassCondition = true;

            _isCollected = true;
        }
    }
}
