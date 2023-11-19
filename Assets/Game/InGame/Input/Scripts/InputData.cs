using UnityEngine;


[CreateAssetMenu(fileName = "InputData", menuName = "HunterTreasure/Input/InputData")]
public class InputData : ScriptableObject
{
    // private properties input horizontal and vertical
    private float _horizontal;
    private float _vertical;

    // private properties input jump
    private bool _jump;

    // public getter setter input horizontal, if value < 0 -> horizontal = -1, if value > 0 -> horizontal = 1, else horizontal = 0
    public float Horizontal
    {
        get => _horizontal;
        set
        {
            if(value < 0)
            {
                _horizontal = -1;
            }
            else if(value > 0)
            {
                _horizontal = 1;
            }
            else
            {
                _horizontal = 0;
            }
        }
    }
    

    public float Vertical
    {
        get => _vertical;
        set
        {
            if (value < 0)
            {
                _vertical = -1;
            }
            else if (value > 0)
            {
                _vertical = 1;
            }
            else
            {
                _vertical = 0;
            }
        }
    }

    public bool Jump
    {
        get => _jump;
        set => _jump = value;
    }
}
