using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ModalDataModel
{
    public ModalType modalType;
    public ModalBase modalPrefab;
}

[CreateAssetMenu(fileName = "HolderDataModel", menuName = "HunterTreasure/UI/HolderDataModel")]
public class HolderDataModel : ScriptableObject
{
    [SerializeField] private List<ModalDataModel> _modalDataModels;

    public ModalBase GetModalPrefab(ModalType modalType)
    {
        foreach (var modalDataModel in _modalDataModels)
        {
            if (modalDataModel.modalType == modalType)
            {
                return modalDataModel.modalPrefab;
            }
        }

        return null;
    }
}
