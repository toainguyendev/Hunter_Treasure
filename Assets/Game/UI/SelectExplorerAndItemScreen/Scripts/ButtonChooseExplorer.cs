using SuperMaxim.Messaging;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChooseExplorer : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Button btnSelect;
    [SerializeField] private Image avtExplorer;
    [SerializeField] private TMP_Text txtName;
    [SerializeField] private GameObject tickSelect;

    private ExplorerType explorerType;

    private void Awake()
    {
        btnSelect.onClick.AddListener(OnClickChooseExplorer);
        Messenger.Default.Subscribe<OnChangeExplorerPayload>(OnChangeExplorer);
    }

    private void OnClickChooseExplorer()
    {
        // send message to change explorer
        Messenger.Default.Publish(new OnChangeExplorerPayload()
        {
            explorerType = this.explorerType
        });
    }

    private void OnChangeExplorer(OnChangeExplorerPayload payload)
    {
        tickSelect.SetActive(payload.explorerType == this.explorerType);
        // send message to change explorer
        Messenger.Default.Publish(new OnChangeExplorerPayload()
        {
            explorerType = this.explorerType
        });
    }

    // method setup avatar and name of explorer
    public void Setup(ExplorerType explorerType, Sprite sprite, string name)
    {
        avtExplorer.sprite = sprite;
        txtName.text = name;
        this.explorerType = explorerType;
    }
}
