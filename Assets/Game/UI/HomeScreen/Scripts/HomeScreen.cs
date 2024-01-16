using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class HomeScreen : ModalBase
{
    [Header("UI Elements")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingButton;
    [SerializeField] private Button shopButton;
    [SerializeField] private Button itemsButton;
    [SerializeField] private Button explorersButton;

    [Space(12)]
    [SerializeField] private Transform holderExplorer;

    [Space(10), Header("Data")]
    [SerializeField] private RuntimeGlobalData runtimeGlobalData;
    [SerializeField] private ExplorerManager explorerManager; 

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
        ConsoleLog.Log("Click setting");
    }

    // Load SceneGame when click button
    public void OnClickPlay()
    {
        UIManager.Instance.ShowModal(ModalType.SELECT_LEVEL);
    }

    protected override void OnClose()
    {
    }

    protected override void OnShow()
    {
        if(runtimeGlobalData.DataInHome.explorer == ExplorerType.None)
            runtimeGlobalData.SetChoseExplorer(ExplorerType.Bishop);

        foreach (Transform child in holderExplorer)
        {
            Destroy(child.gameObject);
        }

        var refExplorer = explorerManager.GetExplorerDisplay(runtimeGlobalData.DataInHome.explorer);
        Addressables.InstantiateAsync(refExplorer).Completed += (AsyncOperationHandle<GameObject> obj) =>
        {
            obj.Result.transform.SetParent(holderExplorer);
            obj.Result.transform.localPosition = Vector3.zero;
            obj.Result.transform.localScale = Vector3.one;
            obj.Result.transform.localRotation = Quaternion.identity;
        };
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
