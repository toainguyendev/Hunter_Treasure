using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu (fileName ="New weapon", menuName= "ScriptableObjects/Weapons")]
public class Weapon : ScriptableObject
{
	public int level;
	public string name;
	public int range;
	public int firepower;
	public int influence_range;
	public Sprite image;
	public Object sceneToLoad;


}
