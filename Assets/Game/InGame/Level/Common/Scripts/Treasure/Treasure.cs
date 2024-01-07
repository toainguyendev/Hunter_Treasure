using UnityEngine;

public class Treasure : MonoBehaviour
{
    [SerializeField] private BaseCondition _baseConditionWin;

    [Space(12)]
    [SerializeField] private BaseCondition[] _conditionsToCollect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (CanCollect() && other.CompareTag("Player"))
        {
            // Do Animation

            // set condition win
            _baseConditionWin.IsPassCondition = true;
        }
    }

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
}
