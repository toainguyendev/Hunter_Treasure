using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDisplay : MonoBehaviour
{

	[SerializeField] private TMP_Text level;
	[SerializeField] private TMP_Text itemName;
	[SerializeField] private TMP_Text range;
	[SerializeField] private TMP_Text damage;
	[SerializeField] private TMP_Text description;
	[SerializeField] private Transform itemHolder;
	//[SerializeField] private Image image;
	public void DisplayItem(ItemBaseData item)
	{
		level.text = "Level \n" + item.Level;
		itemName.text = item.Name;
		range.text = "" + item.Range + "/10";
		damage.text = "" + item.Damage + "/10";
		description.text = item.Description;

		//hide prev item
		foreach (Transform child in itemHolder)
		{
			Destroy(child.gameObject);
		}

		//show item prefab
		GameObject obj = Instantiate(item.ItemPrefab, itemHolder);
		//obj.SetActive(true);
		obj.transform.SetParent(itemHolder);
		obj.transform.localPosition = Vector3.zero;
		obj.transform.localScale = Vector3.one * 1000;
		obj.transform.localRotation = Quaternion.Euler(90, 180, 0);
	}

}
