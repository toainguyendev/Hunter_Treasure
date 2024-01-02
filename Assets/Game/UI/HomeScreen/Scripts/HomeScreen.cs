using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HomeScreen : ModalBase
{
    [Header("UI Elements")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingButton;
    [SerializeField] private Button shopButton;
    [SerializeField] private Button itemsButton;
    [SerializeField] private Button explorersButton;

    [Space(10), Header("Data")]
    [SerializeField] private RuntimeGlobalData runtimeGlobalData;

    private void Awake()
    {
        playButton.onClick.AddListener(OnClickPlay);
        settingButton.onClick.AddListener(OnClickSetting);
        shopButton.onClick.AddListener(OnClickShop);
        itemsButton.onClick.AddListener(OnClickItems);
        explorersButton.onClick.AddListener(OnClickExplorers);
    }

    private void OnClickExplorers()
    {
        UIManager.Instance.ShowModal(ModalType.LIST_EXPLORER);
    }

    private void OnClickItems()
    {
        UIManager.Instance.ShowModal(ModalType.LIST_ITEM);
    }

    private void OnClickShop()
    {
        ConsoleLog.Log("Click shop");
    }

    private void OnClickSetting()
    {
        UIManager.Instance.ShowModal(ModalType.SETTING);
    }

    // Load SceneGame when click button
    public void OnClickPlay()
    {
        // Pass data
        runtimeGlobalData.DataStartGamePlay = new DataStartGamePlay(1, ExplorerType.Bishop);

        // Load scene
        LoadSceneController.Instance.LoadHomeToGame();
    }

    protected override void OnClose()
    {
    }

    protected override void OnShow()
    {
    }

    protected override void OnAnimationEnd()
    {
    }

    private void OnDestroy()
    {
        playButton.onClick.RemoveAllListeners();
        settingButton.onClick.RemoveAllListeners();
        shopButton.onClick.RemoveAllListeners();
        itemsButton.onClick.RemoveAllListeners();
        explorersButton.onClick.RemoveAllListeners();
    }
}
