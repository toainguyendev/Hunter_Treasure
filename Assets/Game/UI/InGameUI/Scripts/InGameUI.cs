using DG.Tweening;
using SuperMaxim.Messaging;
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

    protected override void Awake()
    {
        base.Awake();
        Messenger.Default.Subscribe<ExplorerHealthPayload>(OnExplorerHealthChange);
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
        if (runtimeGlobalData.DataStartGamePlay.ItemsType != null)
        {
            var itemsType = runtimeGlobalData.DataStartGamePlay.ItemsType;
            for (int i = 0; i < itemsType.Count; i++)
            {
                itemUI[i].SetupUI(itemsType[i].Key, itemHolderData.GetItemHolder(itemsType[i].Key).ItemData.Icon, itemsType[i].Value);
            }
        }
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        Messenger.Default.Unsubscribe<ExplorerHealthPayload>(OnExplorerHealthChange);
    }
}
