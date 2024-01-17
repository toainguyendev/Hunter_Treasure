using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
		
		if (Input.GetKeyDown(KeyCode.U))
		{
			itemList[0].ItemSkill.Use(transform);
		}

		if (Input.GetKeyDown(KeyCode.I))
		{
			itemList[1].ItemSkill.Use(transform);
		}

		if (Input.GetKeyDown(KeyCode.O))
		{
			itemList[2].ItemSkill.Use(transform);
		}
	}
}
