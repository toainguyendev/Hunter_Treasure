using Cysharp.Threading.Tasks.Triggers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinDisplay : MonoBehaviour
{
    [SerializeReference] InventoryDataAsset inventoryDataAsset;
    // Start is called before the first frame update
    private void Awake()
    {
        transform.GetComponent<TMP_Text>().text = inventoryDataAsset.Coin.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetComponent<TMP_Text>().text = inventoryDataAsset.Coin.ToString();
    }
}
