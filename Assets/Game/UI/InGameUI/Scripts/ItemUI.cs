using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Image imgIcon;
    [SerializeField] private TMP_Text txtCount;


    private ItemType itemType;

    // setup UI
    public void SetupUI(ItemType itemType, Sprite icon, int count)
    {
        this.itemType = itemType;
        imgIcon.sprite = icon;
        txtCount.text = count.ToString();
    }

    public void ChangeQuantity(int quantity)
    {
        txtCount.text = quantity.ToString();
    }
}
