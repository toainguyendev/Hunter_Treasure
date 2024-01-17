using System.Collections;
using UnityEngine;
using System.Threading.Tasks;
using System.Threading;

public class MineItem : ItemBase
{
	[SerializeField] private GameObject itemPrefab;
	[SerializeField] private GameObject itemEffect;
	[SerializeField] private MineItemData itemInfo;

	public override void Upgrade()
	{
		// Code của bạn cho việc nâng cấp
	}

	public override async void Use(Transform explorerTransform)
	{
		ConsoleLog.Log("Use item: " + itemInfo.Name);
		var explorerPosition = explorerTransform.position;
		var explorerForward = explorerTransform.forward;

		// Đặt vật phẩm trước mặt nhân vật, giả sử offset là (0, 1, 2)
		Vector3 itemPos = explorerPosition + explorerForward * 2 + new Vector3(0, 1, 0);

		GameObject item = Instantiate(itemPrefab, itemPos, Quaternion.identity);
		Rigidbody Rb = item.GetComponent<Rigidbody>();

		if (Rb != null)
		{
			Rb.useGravity = true;
		}

		await Task.Delay(1000);

		if (itemEffect != null && item != null && item.activeInHierarchy)
		{
			GameObject obj = Instantiate(itemEffect, item.transform.position, Quaternion.identity);
			obj.transform.parent = item.transform;
			obj.transform.localPosition = Vector3.zero;
			obj.transform.localRotation = Quaternion.identity;
		}

		//damage
		Collider[] hitColliders = Physics.OverlapSphere(item.transform.position,5);
		foreach (var hitCollider in hitColliders)
		{
			var enemyHealth = hitCollider.GetComponent<EnemyHealthBase>();
			if (enemyHealth != null)
			{
				enemyHealth.TakeDamage(100);
			}
		}
		gameObject.SetActive(false);
	}
}
