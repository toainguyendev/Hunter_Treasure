using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class ResultScreen : ModalBase
{
    [Header("UI")]
    [SerializeField] private TMP_Text _txtTitle;
    [SerializeField] private TMP_Text _txtCoin;
    [SerializeField] private Image _imgGem;
    [SerializeField] private TMP_Text _txtCannotReceiveReward;
    [SerializeField] private Button _btnBackToHome;

    [Space(10), Header("Data")]
    [SerializeField] private LevelConfigs _levelConfig;
    [SerializeField] private ExplorerManager _explorerManager;
    [SerializeField] private RuntimeGlobalData _runtimeGlobalData;

    private void Awake()
    {
        _btnBackToHome.onClick.AddListener(() =>
        {
            LoadSceneController.Instance.LoadGameToHome();
        });
    }

    private void OnEnable()
    {
        SetupUI().Forget();
    }

    public async UniTask SetupUI()
    {
        if(_runtimeGlobalData.DataEndGame.IsWin)
        {
            _txtTitle.text = "You Win";
            _txtTitle.color = Color.green;
            _txtCannotReceiveReward.text = "Reward";
        }
        else
        {
            _txtTitle.text = "You Lose";
            _txtTitle.color = Color.red;
        }
        _txtCannotReceiveReward.gameObject.SetActive(true);

        // setup coin
        _txtCoin.text = _levelConfig.GetLevelData(_runtimeGlobalData.DataEndGame.LevelId).coinReward.ToString();

        // setup gem
        _imgGem.sprite = _levelConfig.GetLevelData(_runtimeGlobalData.DataEndGame.LevelId).treasureData.avatar;
    }

    private void OnDestroy()
    {
        _btnBackToHome.onClick.RemoveAllListeners();
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
}
