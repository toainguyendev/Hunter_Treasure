using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;
public class ListExplorerScreen : ModalBase
{
    // Start is called before the first frame update
    [Header("Explorer Manager")]
    [SerializeField] private ExplorerManager explorerManager;

    [Space(12), Header("UI")]
    [SerializeField] private TMP_Text explorerName;
    [SerializeField] private Transform holderExplorer;
    [SerializeField] private Button btnBack;
    [SerializeField] private Button btnUseExplorer;

    [Header("Explorer Sidebar List")]
    [SerializeField] private GameObject explorerItem;
    [SerializeField] private GameObject listExplorerContainer;

    [Header("Upgrade panel")]
    [SerializeField] private Button upgradeButton;
    [SerializeField] private GameObject UpgradePanel;

    [Header("Data")]
    [SerializeReference] private LevelDataAsset levelDataAsset;
    [SerializeField] private RuntimeGlobalData runtimeGlobalData;

    ExplorerHolderData[] explorerHolderDatas;
    private int currentExplorerIndex = 0;

    private void Awake()
    {
        explorerHolderDatas = explorerManager.ExplorerHolderDatas;

        DisplayExplorer(explorerHolderDatas[0]);

        for (int i = 0; i < explorerHolderDatas.Length; i++)
        {
            GameObject explorerItemInstance = Instantiate(explorerItem, listExplorerContainer.transform);
            Image characterImage = explorerItemInstance.GetComponentInChildren<Image>();
            TMP_Text characterTitle = explorerItemInstance.GetComponentInChildren<TMP_Text>();
            int index = i;
            explorerItemInstance.GetComponent<Button>()?.onClick.AddListener(() => {
                currentExplorerIndex = index;
                DisplayExplorer(explorerHolderDatas[currentExplorerIndex]);
            });
            characterImage.sprite = explorerHolderDatas[i].explorerBaseInfo.ImageThumbnail;
            characterTitle.text = explorerHolderDatas[i].explorerBaseInfo.Name;
        }

        btnBack.onClick.AddListener(() =>
        {
            UIManager.Instance.ShowModal(ModalType.HOME);
        });

        upgradeButton.onClick.AddListener(() =>
        {
            ShowUpgradePanal();
        });

        btnUseExplorer.onClick.AddListener(() =>
        {
            runtimeGlobalData.SetChoseExplorer(explorerHolderDatas[currentExplorerIndex].explorer);
        });
    }

    public void DisplayExplorer(ExplorerHolderData _explorer)
    {
        explorerName.text = _explorer.explorerBaseInfo.Name + " - Level " + 
            levelDataAsset.getCurrentLevel(_explorer.explorer);
        foreach (Transform child in holderExplorer)
        {
            Destroy(child.gameObject);
        }
        var refExplorer = _explorer.explorerDisplayPrefab;
        Addressables.InstantiateAsync(refExplorer).Completed += (AsyncOperationHandle<GameObject> obj) =>
        {
            obj.Result.transform.SetParent(holderExplorer);
            obj.Result.transform.localPosition = Vector3.zero;
            obj.Result.transform.localScale = Vector3.one;
            obj.Result.transform.localRotation = Quaternion.identity;
        };
    }
    public void ChangeExplorer(int _change)
    {
        ConsoleLog.Log("Change explorer: " + _change);
        currentExplorerIndex += _change;
        if (currentExplorerIndex < 0)
        {
            currentExplorerIndex = explorerHolderDatas.Length - 1;
        }
        else if (currentExplorerIndex > explorerHolderDatas.Length - 1)
        {
            currentExplorerIndex = 0;
        }
        if (explorerHolderDatas != null)
        {
            DisplayExplorer(explorerHolderDatas[currentExplorerIndex]);
        }
    }

    public ExplorerBaseInfo GetCurrentExplorerBaseInfo()
    {
        ExplorerType explorerType = explorerHolderDatas[currentExplorerIndex].explorer;
        return levelDataAsset.GetExplorerBaseInfoWithLevel(explorerType);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangeExplorer(-1);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangeExplorer(1);
        }
        explorerName.text = explorerHolderDatas[currentExplorerIndex].explorerBaseInfo.Name + " - Level " +
            levelDataAsset.getCurrentLevel(explorerHolderDatas[currentExplorerIndex].explorer);
    }

    public void ShowUpgradePanal()
    {
        ExplorerType explorerType = explorerHolderDatas[currentExplorerIndex].explorer;
        int level = levelDataAsset.getCurrentLevel(explorerType);

        if (level < 3)
        {
            UpgradePanel.GetComponent<UpgradeExplorerPopup>().SetData(explorerType, level);
            holderExplorer.gameObject.SetActive(false);
            UpgradePanel.SetActive(true);
        }
        else
        {

        }
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
        btnBack.onClick.RemoveAllListeners();
    }
}
