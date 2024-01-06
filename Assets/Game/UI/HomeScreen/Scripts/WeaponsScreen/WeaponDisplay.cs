using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDisplay : MonoBehaviour
{

	[SerializeField] private TMP_Text level;
	[SerializeField] private TMP_Text name;
	[SerializeField] private TMP_Text range;
	[SerializeField] private TMP_Text firepower;
	[SerializeField] private TMP_Text influence_range;
	[SerializeField] private Image image;


	public void DisplayItem(Weapon _weapon)
	{
		level.text = "Level \n" + _weapon.level;
		name.text = _weapon.name;
		range.text = "" + _weapon.range + "/10";
		firepower.text = "" + _weapon.firepower + "/10";
		influence_range.text = "" + _weapon.influence_range + "/10";
		image.sprite = _weapon.image;
	}

}
