using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
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
	public void DisplayItem(ItemHolder item)
	{
		level.text = "Level \n" + item.ItemData.Level;
		itemName.text = item.ItemData.Name;
		range.text = "" + item.ItemData.Range + "/10";
		damage.text = "" + item.ItemData.Damage + "/10";
		description.text = item.ItemData.Description;

		//hide prev item
		foreach (Transform child in itemHolder)
		{
			Destroy(child.gameObject);
		}

        var refExplorer = item.ItemDisplayPrefab;
        Addressables.InstantiateAsync(refExplorer).Completed += (AsyncOperationHandle<GameObject> obj) =>
        {
			switch (item.ItemType)
			{
				case ItemType.Material:
				{
                    obj.Result.transform.SetParent(itemHolder);
                    obj.Result.transform.localPosition = new Vector3(0, 0, -5); ;
                    obj.Result.transform.localScale = Vector3.one * 500;
                    obj.Result.transform.localRotation = Quaternion.Euler(-90, 45, 0); ;
                    break;
                }
				case ItemType.Mine:
					{
                    obj.Result.transform.SetParent(itemHolder);
                    obj.Result.transform.localPosition = Vector3.zero;
                    obj.Result.transform.localScale = Vector3.one * 700;
                    obj.Result.transform.localRotation = Quaternion.Euler(90, 180, 0); 
                    break;
                }
                case ItemType.Trap:
                {
                    obj.Result.transform.SetParent(itemHolder);
                    obj.Result.transform.localPosition = new Vector3(0, -200, -5);
                    obj.Result.transform.localScale = Vector3.one * 100;
                    obj.Result.transform.localRotation = Quaternion.Euler(0, 90, 0);
                        break;
                }
            }

        };
    }

}
