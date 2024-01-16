using System.Collections;
using UnityEngine;
using static UnityEditor.Progress;

public class FlagItem : ItemBase
{
	[SerializeField] private GameObject itemPrefab;
	[SerializeField] private GameObject itemEffect;

	public override void Upgrade()
	{

	}

	public override void Use(Transform explorerTransform)
	{
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

	}
}
