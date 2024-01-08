using SuperMaxim.Messaging;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public struct OnChangeExplorerPayload
{
    public ExplorerType explorerType;
}

public struct OnChangeQuantityItemPayload
{
    public ItemType itemType;
}

public class SelectionScreen : ModalBase
{
    [Header("UI")]
    [SerializeField] private Transform holderExplorerModel;
    [SerializeField] private Transform holderExplorerListButton;
    [SerializeField] private Transform holderItemListButton;

    [Space(8)]
    [SerializeField] private List<SelectedItemControll> selectedItemUIControlls;

    [Space(12), Header("Prefab")]
    [SerializeField] private AssetReferenceT<GameObject> refBtnChooseExplorer;
    [SerializeField] private AssetReferenceT<GameObject> refBtnChooseItem;

    [Space(12), Header("Data")]
    [SerializeField] private ExplorerManager explorerManager;
    [SerializeField] private ItemHolderData itemHolderData;
    [SerializeField] private RuntimeGlobalData runtimeGlobalData;

    private ExplorerType selectedExplorer = ExplorerType.None;

    private void Awake()
    {
        Messenger.Default.Subscribe<OnChangeExplorerPayload>(OnSelectNewExplorer);
        Messenger.Default.Subscribe<OnChangeQuantityItemPayload>(OnChangeQuantityItem);
    }



    private void OnEnable()
    {
        CreateExplorerModelDisplay(runtimeGlobalData.DataInHome.explorer);
        CreateListButtonExplorer();
        CreateListButtonItems();
    }

    protected override void OnAnimationEnd()
    {
    }

    protected override void OnClose()
    {
    }

    protected override void OnShow()
    {
    }

    private void CreateListButtonExplorer()
    {
        foreach (ExplorerHolderData explorerHolderData in explorerManager.ExplorerHolderDatas)
        {
            // create instance for button choose explorer
            AssetReferenceT<GameObject> assetReference = refBtnChooseExplorer;
            AsyncOperationHandle<GameObject> handle = Addressables.InstantiateAsync(assetReference);
            
            handle.Completed += (obj) =>
            {
                if (obj.Status == AsyncOperationStatus.Succeeded)
                {
                    var buttonChooseExplorer = obj.Result.GetComponent<ButtonChooseExplorer>();
                    buttonChooseExplorer.Setup(explorerHolderData.explorer, explorerHolderData.explorerBaseInfo.ImageThumbnail, explorerHolderData.explorerBaseInfo.Name);

                    // set parent for button choose explorer
                    buttonChooseExplorer.transform.SetParent(holderExplorerListButton);
                }
            };
        }
    }

    private void CreateListButtonItems()
    {
        foreach (ItemHolder itemHolder in itemHolderData.ItemHolders)
        {
            // create instance for button choose item
            AssetReferenceT<GameObject> assetReference = refBtnChooseItem;
            AsyncOperationHandle<GameObject> handle = Addressables.InstantiateAsync(assetReference);

            handle.Completed += (obj) =>
            {
                if (obj.Status == AsyncOperationStatus.Succeeded)
                {
                    // get component ButtonChooseItem
                    var buttonChooseItem = obj.Result.GetComponent<ButtonChooseItem>();
                    buttonChooseItem.Setup(itemHolder.ItemType, itemHolder.ItemData.Icon, itemHolder.ItemData.Name);

                    buttonChooseItem.transform.SetParent(holderItemListButton);
                }
            };
        }
    }

    private void OnSelectNewExplorer(OnChangeExplorerPayload payload)
    {
        selectedExplorer = payload.explorerType;
        if (selectedExplorer == ExplorerType.None)
        {
            selectedExplorer = ExplorerType.Bishop;
        }
        CreateExplorerModelDisplay(selectedExplorer);
    }

    private void CreateExplorerModelDisplay(ExplorerType explorerType)
    {
        if(holderExplorerModel.childCount > 0)
        {
            Destroy(holderExplorerModel.GetChild(0).gameObject);
        }

        AssetReferenceT<GameObject> assetReference = explorerManager.GetExplorerDisplay(explorerType);
        AsyncOperationHandle<GameObject> handle = Addressables.InstantiateAsync(assetReference);

        handle.Completed += (obj) =>
        {
            if (obj.Status == AsyncOperationStatus.Succeeded)
            {
                GameObject explorer = obj.Result;
                explorer.transform.SetParent(holderExplorerModel);
                explorer.transform.localPosition = Vector3.zero;
                explorer.transform.localScale = Vector3.one;
            }
        };
    }


    private void OnChangeQuantityItem(OnChangeQuantityItemPayload payload)
    {
        for(int i = 0; i < selectedItemUIControlls.Count; i++)
        {
            bool setupSuccess = selectedItemUIControlls[i].SetupSelectedItem(payload.itemType, itemHolderData.GetItemHolder(payload.itemType).ItemData.Icon);
            if (setupSuccess)
            {
                break;
            }
        }
    }


    private void OnDestroy()
    {
        Messenger.Default.Unsubscribe<OnChangeExplorerPayload>(OnSelectNewExplorer);
    }
}
