using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponIcon : MonoBehaviour
{
	[SerializeField] private Image image;
	[SerializeField] private TMP_Text level;

	private WeaponDisplay weaponDisplay;
	private ItemHolder item;

	private Button button;

	void handleClickItem()
	{
		weaponDisplay.DisplayItem(item);
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

	public void DisplayItem(ItemHolder _item, WeaponDisplay _weaponDisplay)
	{
		level.text = "" + _item.ItemData.Level;
		image.sprite = _item.ItemData.Icon;

		item = _item;
		weaponDisplay = _weaponDisplay;
	}
}
