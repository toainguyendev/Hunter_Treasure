using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class UsingItem : MonoBehaviour
{
    //In Game UI
	private InGameUI inGameUI;
	private List<ItemHolder> itemList;

	//Rigidbody
	public float ItemDistance = 5.0f;
	public float Push = 0.5f;

	private void Awake()
	{
		inGameUI = InGameUI.Instance;
		itemList = inGameUI.ItemList;
	}

	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		
		if (Input.GetKeyDown(KeyCode.U))
		{
			useItem(0);
		}

		if (Input.GetKeyDown(KeyCode.I))
		{
			useItem(1);
		}

		if (Input.GetKeyDown(KeyCode.O))
		{
			useItem(2);
		}
	}
	private void useItem(int index)
	{
		var explorerPosition = transform.position;
		var explorerForward = transform.forward;

		// Đặt vật phẩm trước mặt nhân vật, giả sử offset là (0, 1, 2)
		Vector3 itemPos = explorerPosition + explorerForward * 2 + new Vector3(0, 1, 0);

		GameObject item = Instantiate(itemList[index].ItemData.ItemPrefab, itemPos, Quaternion.identity);
		Rigidbody Rb = item.GetComponent<Rigidbody>();

		if (Rb != null)
		{
			Rb.useGravity = true;
		}

		//using
		itemList[index].ItemSkill.Use();
	}
}
