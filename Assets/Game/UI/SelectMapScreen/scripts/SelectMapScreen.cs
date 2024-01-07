using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class SelectMapScreen : ModalBase
{

    [Header("UI Elements")]
    [SerializeField] private GameObject[] levelObjects;

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

        for (int i = 0; i < levelDatas.Length && i< levelObjects.Length; i++)
        {
            GameObject level = levelObjects[i];
            level.GetComponent<MapItem>().setLevelData(levelDatas[i]);
        }

    }
}
