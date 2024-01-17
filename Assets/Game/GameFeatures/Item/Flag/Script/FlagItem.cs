using System.Collections;
using UnityEngine;
using static UnityEditor.Progress;
using System.Threading.Tasks;
using System.Threading;

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

		//thu hut dich
		ActivateItem(item);

	}

    async private void ActivateItem(GameObject item)
    {

        // Kích hoạt đối tượng trước khi kiểm tra va chạm
        //item.SetActive(true);

        // Kiểm tra va chạm trong mỗi frame
        Collider[] hitColliders = Physics.OverlapSphere(item.transform.position, 5);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider)
            {
                var enemySM = hitCollider.GetComponent<EnemyStateManagement>();
                var trackTarget = hitCollider.GetComponent<TrackTarget>();
                if (enemySM != null && trackTarget != null)
                {
                    //enemyHealth.TakeDamage(100);
                    trackTarget._attractivePos = item.transform.position;
                    enemySM.IsAttractived = true;
                    await Task.Delay(3000);
                    enemySM.IsAttractived = false;
                }
            }
        }

        await Task.Delay(500);
        DestroyImmediate(item);
    }
}
