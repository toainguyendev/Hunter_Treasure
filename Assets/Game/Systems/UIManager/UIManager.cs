using System.Collections.Generic;
using UnityEngine;


// enum type for modal
public enum ModalType
{
    HOME,
    SETTING,
    LIST_ITEM,
    LIST_EXPLORER,
    SELECT_LEVEL,
    SELECT_EXPLORER_AND_ITEM,
}

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] private HolderDataModel _holderDataModel;

    // dictionary for modal
    private Dictionary<ModalType, ModalBase> _modals = new Dictionary<ModalType, ModalBase>();

    private ModalBase _currentModalOpened;
    // method show modal
    public void ShowModal(ModalType modalType)
    {
        // if modal is not exist in dictionary
        if (!_modals.ContainsKey(modalType))
        {
            // create modal
            ModalBase modal = Instantiate(_holderDataModel.GetModalPrefab(modalType), transform);

            // add modal to dictionary
            _modals.Add(modalType, modal);
        }

        // show modal
        _modals[modalType].Show();

        _currentModalOpened?.Close();
        _currentModalOpened = _modals[modalType];
    }

    public void CloseModal(ModalType modalType)
    {
        // if modal is exist in dictionary
        if (_modals.ContainsKey(modalType))
        {
            // close modal
            _modals[modalType].Close();
        }
    }

    public void CloseAllModal()
    {
        // loop all modal in dictionary
        foreach (var modal in _modals)
        {
            // close modal
            modal.Value.Close();
        }
    }

    public void CloseAllModalExcept(ModalType modalType)
    {
        // loop all modal in dictionary
        foreach (var modal in _modals)
        {
            // if modal is not modalType
            if (modal.Key != modalType)
            {
                // close modal
                modal.Value.Close();
            }
        }
    }

    public void DestroyModal(ModalType modalType)
    {
        // if modal is exist in dictionary
        if (_modals.ContainsKey(modalType))
        {
            // destroy modal
            Destroy(_modals[modalType].gameObject);

            // remove modal from dictionary
            _modals.Remove(modalType);
        }
    }

    // destroy all modal
    public void DestroyAllModal()
    {
        // loop all modal in dictionary
        foreach (var modal in _modals)
        {
            // destroy modal
            Destroy(modal.Value.gameObject);
        }

        // clear dictionary
        _modals.Clear();
    }
}
