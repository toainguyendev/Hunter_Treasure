using UnityEngine.UI;
using UnityEngine;

public class WeaponsScreen : ModalBase
{
    [Header("UI Elements")]
    [SerializeField] private Button btnBack;


    private void Awake()
    {
        btnBack.onClick.AddListener(() =>
        {
            UIManager.Instance.ShowModal(ModalType.HOME);
        });
    }

    private void OnDestroy()
    {
        btnBack.onClick.RemoveAllListeners();
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
}
