using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class SelectMapScreen : ModalBase
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
    // Start is called before the first frame update
    [SerializeField] private LevelConfigs levelDataManager;

    LevelData[] levelDatas;

    protected override void OnAnimationEnd()
    {
        throw new System.NotImplementedException();
    }

    protected override void OnClose()
    {
        throw new System.NotImplementedException();
    }

    protected override void OnShow()
    {
        throw new System.NotImplementedException();
    }

    private void Awake()
    {
        levelDatas = levelDataManager.getLevelDatas();

        Debug.Log(levelDatas.Length);
        //DisplayExplorer(explorerBaseInfos[0]);

        //for (int i = 0; i < explorerBaseInfos.Length; i++)
        //{
        //    GameObject explorerItemInstance = Instantiate(explorerItem, listExplorerContainer.transform);
        //    Image characterImage = explorerItemInstance.GetComponentInChildren<Image>();
        //    TMP_Text characterTitle = explorerItemInstance.GetComponentInChildren<TMP_Text>();
        //    int index = i;
        //    explorerItemInstance.GetComponent<Button>()?.onClick.AddListener(() => {
        //        currentExplorerIndex = index;
        //        Debug.Log("Current explorer index: " + currentExplorerIndex);
        //        DisplayExplorer(explorerBaseInfos[currentExplorerIndex]);
        //    });
        //    characterImage.sprite = explorerBaseInfos[i].ImageThumbnail;
        //    characterTitle.text = explorerBaseInfos[i].Name;
        //}

    }
}
