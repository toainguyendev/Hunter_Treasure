
using UnityEngine;

public abstract class ItemBaseData : ScriptableObject
{
    //create private properties name, description, icon
    [SerializeField] private string itemName;
    [SerializeField] private string description;
    [SerializeField] private Sprite icon;
	[SerializeField] private int level;
	[SerializeField] private int range;
	[SerializeField] private int damage;
	[SerializeField] private GameObject itemPrefab;
	[SerializeField] private GameObject itemEffect;


	//create public getter for name, description, icon
	public string Name => itemName;
    public string Description => description;
    public Sprite Icon => icon;
	public int Level => level;
	public int Range => range;
	public int Damage => damage;
	public GameObject ItemPrefab => itemPrefab;
	public GameObject ItemEffect => itemEffect;
}
