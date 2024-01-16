using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class BloodItem : ItemBase
{
	[SerializeField] private GameObject itemPrefab;
	[SerializeField] private GameObject itemEffect;

	//[SerializeField] private CommonMapData commonMapData;

	[SerializeField] private int plusNumber = 200;



	public override void Upgrade()
	{

	}

	public void Awake()
	{

	}

	public override void Use(Transform explorerTransform)
	{
		explorerTransform.GetComponent<HealthBase>().Heal(plusNumber);
	}

}
