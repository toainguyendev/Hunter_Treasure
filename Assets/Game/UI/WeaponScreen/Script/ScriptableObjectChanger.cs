using UnityEngine;

public class ScriptableObjectChanger : MonoBehaviour
{
    [SerializeField] private ScriptableObject[] serializableObjects;

	[SerializeField] private WeaponDisplay weaponDisplay;

	[SerializeField] private GameObject weaponList;

	[SerializeField] private GameObject weaponItemPrefab;


	private void Awake()
	{
		GenerateWeaponList();
		weaponDisplay.DisplayItem((Weapon)serializableObjects[0]);
		
	}

	private void GenerateWeaponList()
	{
		foreach (ScriptableObject info in serializableObjects)
		{
			// Tạo một WeaponItem từ Prefab
			GameObject weaponItemObject = Instantiate(weaponItemPrefab, weaponList.transform);

			// Lấy thành phần WeaponItem từ đối tượng mới tạo
			WeaponIcon weaponIcon = weaponItemObject.GetComponent<WeaponIcon>();

			

			// Kiểm tra xem thành phần có tồn tại không
			if (weaponIcon != null)
			{
				Debug.Log(weaponIcon.ToString());
				// Thiết lập thông tin cho WeaponItem từ mảng thông tin
				weaponIcon.DisplayItem((Weapon)info, weaponDisplay);
			}
			else
			{
				Debug.LogError("WeaponItem component not found on the prefab!");
			}
		}
	}


}
