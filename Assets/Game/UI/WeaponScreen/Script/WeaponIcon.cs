using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponIcon : MonoBehaviour
{
	[SerializeField] private Image image;
	[SerializeField] private TMP_Text level;

	private WeaponDisplay weaponDisplay;
	private Weapon weapon;

	private Button button;

	void handleClickItem()
	{
		Debug.Log("a");
		weaponDisplay.DisplayItem(weapon);
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

	public void DisplayItem(Weapon _weapon, WeaponDisplay _weaponDisplay)
	{
		Debug.Log(_weapon.image);
		level.text = "" + _weapon.level;
		image.sprite = _weapon.image;

		weapon = _weapon;
		weaponDisplay = _weaponDisplay;
	}
}
