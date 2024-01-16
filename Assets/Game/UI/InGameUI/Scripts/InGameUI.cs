using DG.Tweening;
using SuperMaxim.Messaging;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct ExplorerHealthPayload
{
    public float maxHP;
    public float currentHP;
}

public class InGameUI : MonoSingleton<InGameUI>
{
    [Header("UI Controller")]
    [SerializeField] private SkillUI skillUI;
    [SerializeField] private ItemUI[] itemUI;

    [Space(12), Header("UI")]
    [SerializeField] private Image explorerAvatar;
    [SerializeField] private Slider healthBar;

	[Header("Data")]
    [SerializeField] private RuntimeGlobalData runtimeGlobalData;
    [SerializeField] private ExplorerManager explorerManager;
    [SerializeField] private ItemHolderData itemHolderData;
    private List<ItemHolder> itemList;

    public List<ItemHolder> ItemList => itemList;

	protected override void Awake()
    {
        base.Awake();
        Messenger.Default.Subscribe<ExplorerHealthPayload>(OnExplorerHealthChange);
        itemList = new List<ItemHolder>();
    }

    private void OnExplorerHealthChange(ExplorerHealthPayload payload)
    {
        healthBar.maxValue = payload.maxHP;
        healthBar.DOValue(payload.currentHP, 0.5f);
    }

    public void SetupUI()
    {
        // setup avatar for explorer
        ExplorerBaseInfo explorerBaseInfo = explorerManager.GetExplorerBaseInfo(runtimeGlobalData.DataStartGamePlay.Explorer);
        explorerAvatar.sprite = explorerBaseInfo.ImageThumbnail;

        // setup skill UI
        skillUI.SetupUI(explorerBaseInfo.SkillData.Icon);

        // Setup healthbar
        healthBar.maxValue = explorerBaseInfo.HP;
        healthBar.value = explorerBaseInfo.HP;

        // setup Item UI
        /*if (runtimeGlobalData.DataStartGamePlay.ItemsType != null)
        {
            var itemsType = runtimeGlobalData.DataStartGamePlay.ItemsType;
            for (int i = 0; i < itemsType.Count; i++)
            {
                itemUI[i].SetupUI(itemsType[i].Key, itemHolderData.GetItemHolder(itemsType[i].Key).ItemData.Icon, itemsType[i].Value);
            }
        }*/
        var itemHolder = itemHolderData.ItemHolders;
		for (int i = 0; i < 3; i++)
		{
			Debug.Log(i + " : " + itemHolder[i]);
			//itemUI[i].SetupUI(itemsType[i].Key, itemHolderData.GetItemHolder(itemsType[i].Key).ItemData.Icon, itemsType[i].Value);
			itemUI[i].SetupUI(itemHolder[i].ItemType, itemHolder[i].ItemData.Icon, 5);
            itemList.Add(itemHolder[i]);
		}
	}

    protected override void OnDestroy()
    {
        base.OnDestroy();
        Messenger.Default.Unsubscribe<ExplorerHealthPayload>(OnExplorerHealthChange);
    }
}
