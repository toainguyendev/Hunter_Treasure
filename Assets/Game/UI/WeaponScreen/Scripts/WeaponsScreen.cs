using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class WeaponsScreen : ModalBase
{
	[Header("Item Manager")]
	[SerializeField] private ItemHolderData itemHolderData;

	[Header("UI Elements")]
    [SerializeField] private Button btnBack;
	[SerializeField] private WeaponDisplay weaponDisplay;

	[Header("Item List")]
	[SerializeField] private GameObject weaponItemPrefab;
	[SerializeField] private GameObject weaponList;

	//list items
	List<ItemHolder> itemHolders;


	private void Awake()
    {
        itemHolders = itemHolderData.ItemHolders;

        //display first item
        weaponDisplay.DisplayItem(itemHolders[0]);
		GenerateWeaponList();

		btnBack.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            UIManager.Instance.ShowModal(ModalType.HOME);
            
        });
    }

	private void GenerateWeaponList()
	{
		foreach (ItemHolder info in itemHolders)
		{
			// Tạo một WeaponItem từ Prefab
			GameObject weaponItemObject = Instantiate(weaponItemPrefab, weaponList.transform);

			// Lấy thành phần WeaponItem từ đối tượng mới tạo
			WeaponIcon weaponIcon = weaponItemObject.GetComponent<WeaponIcon>();

			// Kiểm tra xem thành phần có tồn tại không
			if (weaponIcon != null)
			{
				weaponIcon.DisplayItem(info, weaponDisplay);
			}
			else
			{
				Debug.LogError("WeaponItem component not found on the prefab!");
			}
		}
	}


	private void OnDestroy()
    {
        btnBack.onClick.RemoveAllListeners();
    }


    protected override void OnAnimationEnd()
    {
    }

    protected override void OnClose()
    {
    }

    protected override void OnShow()
    {
    }
}
