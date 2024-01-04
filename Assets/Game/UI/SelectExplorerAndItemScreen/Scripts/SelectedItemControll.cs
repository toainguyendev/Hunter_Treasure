using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectedItemControll : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_Text txtQuantity;
    [SerializeField] private Button btnDecrease;
    [SerializeField] private Button btnRemove;
    [SerializeField] private Image avtItem;

    private ItemType itemType;
    private int quantity;

    private void Awake()
    {
        quantity = 0;
        itemType = ItemType.None;

        btnDecrease.onClick.AddListener(OnClickDecrease);
        btnRemove.onClick.AddListener(OnClickRemove);
    }

    private void OnClickRemove()
    {
        throw new NotImplementedException();
    }

    private void OnClickDecrease()
    {
        throw new NotImplementedException();
    }

    public bool SetupSelectedItem(ItemType itemType, Sprite avatar)
    {
        if(this.itemType == ItemType.None)
        {
            this.itemType = itemType;
            avtItem.sprite = avatar;
        }

        if (this.itemType != itemType)
            return false;

        quantity++;
        txtQuantity.text = quantity.ToString();

        return true;
    }
}
