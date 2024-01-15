using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class SelectMapScreen : ModalBase
{

    [Header("UI Elements")]
    [SerializeField] private GameObject[] levelObjects;
    [SerializeField] private Button btnBack;


    [Space(10), Header("Data")]
    // Start is called before the first frame update
    [SerializeField] private LevelConfigs levelDataManager;

    LevelData[] levelDatas;

    protected override void OnAnimationEnd()
    {
    }

    protected override void OnClose()
    {
    }

    protected override void OnShow()
    {
    }

    private void Awake()
    {
        btnBack.onClick.AddListener(() =>
        {
            UIManager.Instance.ShowModal(ModalType.HOME);
        });
        levelDatas = levelDataManager.getLevelDatas();

        for (int i = 0; i < levelDatas.Length && i< levelObjects.Length; i++)
        {
            GameObject level = levelObjects[i];
            level.GetComponent<MapItem>().setLevelData(levelDatas[i]);
        }

    }
}
