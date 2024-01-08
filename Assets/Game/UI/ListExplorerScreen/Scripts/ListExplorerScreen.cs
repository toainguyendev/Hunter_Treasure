using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;
public class ListExplorerScreen : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Explorer Manager")]
    [SerializeField] private ExplorerManager explorerManager;
    [Header("Explorer Display Data")]
    [SerializeField] private TMP_Text explorerName;
    [SerializeField] private Transform holderExplorer;

    [Header("Explorer Sidebar List")]
    [SerializeField] private GameObject explorerItem;
    [SerializeField] private GameObject listExplorerContainer;



    ExplorerHolderData[] explorerHolderDatas;
    private int currentExplorerIndex = 0;

    private void Awake()
    {
        explorerHolderDatas = explorerManager.ExplorerHolderDatas;

        Debug.Log(explorerHolderDatas.Length);
        DisplayExplorer(explorerHolderDatas[0]);

        for (int i = 0; i < explorerHolderDatas.Length; i++)
        {
            GameObject explorerItemInstance = Instantiate(explorerItem, listExplorerContainer.transform);
            Image characterImage = explorerItemInstance.GetComponentInChildren<Image>();
            TMP_Text characterTitle = explorerItemInstance.GetComponentInChildren<TMP_Text>();
            int index = i;
            explorerItemInstance.GetComponent<Button>()?.onClick.AddListener(() => {
                currentExplorerIndex = index;
                Debug.Log("Current explorer index: " + currentExplorerIndex);
                DisplayExplorer(explorerHolderDatas[currentExplorerIndex]);
                });
            characterImage.sprite = explorerHolderDatas[i].explorerBaseInfo.ImageThumbnail;
            characterTitle.text = explorerHolderDatas[i].explorerBaseInfo.Name;
        }

    }

    public void DisplayExplorer(ExplorerHolderData _explorer)
    {
        explorerName.text = _explorer.explorerBaseInfo.Name;
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
        return explorerHolderDatas[currentExplorerIndex].explorerBaseInfo;
    }

}
