using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SuperMaxim.Messaging;

public class ButtonChooseItem : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Button btnSelect;
    [SerializeField] private Image avtExplorer;
    [SerializeField] private TMP_Text txtName;

    private ItemType itemType;

    private void Awake()
    {
        btnSelect.onClick.AddListener(OnClickChooseItem);
    }



    private void OnClickChooseItem()
    {
        // send message to change explorer
        Messenger.Default.Publish(new OnChangeQuantityItemPayload()
        {
            itemType = this.itemType,
        });
    }

    public void Setup(ItemType itemType, Sprite sprite, string name)
    {
        // setup avatar and name of item
        this.itemType = itemType;
        avtExplorer.sprite = sprite;
        txtName.text = name;
    }
}
