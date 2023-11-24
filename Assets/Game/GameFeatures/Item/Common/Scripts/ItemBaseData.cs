
using UnityEngine;

public abstract class ItemBaseData : ScriptableObject
{
    //create private properties name, description, icon
    [SerializeField] private string itemName;
    [SerializeField] private string description;
    [SerializeField] private Sprite icon;


    //create public getter for name, description, icon
    public string Name => itemName;
    public string Description => description;
    public Sprite Icon => icon;
}
