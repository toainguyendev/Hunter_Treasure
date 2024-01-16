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

	private Transform transform;

	//Rigidbody
	public float ItemDistance = 5.0f;
	public float Push = 0.3f;

	private void Awake()
	{
		inGameUI = InGameUI.Instance;
		itemList = inGameUI.ItemList;
		transform = GetComponent<Transform>();
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
		Vector3 itemPos = explorerPosition;
		itemPos.y += 1;
		GameObject item = Instantiate(itemList[index].ItemData.ItemPrefab, itemPos, Quaternion.identity);
		Rigidbody Rb = item.GetComponent<Rigidbody>();
		if (Rb != null)
		{
			Rb.AddForce(explorerForward * Push, ForceMode.Impulse);
			Rb.useGravity = true;
		}
	}
}
