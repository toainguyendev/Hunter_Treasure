using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponIcon : MonoBehaviour
{
	[SerializeField] private Image image;
	[SerializeField] private TMP_Text level;

	private WeaponDisplay weaponDisplay;
	private ItemBaseData itemData;

	private Button button;

	void handleClickItem()
	{
		Debug.Log("a");
		weaponDisplay.DisplayItem(itemData);
	}

	void Start()
    {
        button = GetComponent<Button>();
		button.onClick.AddListener(handleClickItem);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void DisplayItem(ItemBaseData _item, WeaponDisplay _weaponDisplay)
	{
		level.text = "" + _item.Level;
		image.sprite = _item.Icon;

		itemData = _item;
		weaponDisplay = _weaponDisplay;
	}
}
