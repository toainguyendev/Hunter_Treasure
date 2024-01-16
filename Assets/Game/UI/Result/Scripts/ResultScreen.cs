using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ResultScreen : MonoSingleton<ResultScreen>
{
    [SerializeField] private TMP_Text _txtTitle;
    [SerializeField] private Transform _posSpawnExplorerDisplay;
    [SerializeField] private TMP_Text _txtCoin;
    [SerializeField] private Transform _posSpawnGemDisplay;
    [SerializeField] private TMP_Text _txtCannotReceiveReward;

    [Space(10), Header("Data")]
    [SerializeField] private LevelConfigs _levelConfig;
    [SerializeField] private ExplorerManager _explorerManager;
    [SerializeField] private RuntimeGlobalData _runtimeGlobalData;

    private async void SetupUI()
    {
        if(_runtimeGlobalData.DataEndGame.IsWin)
        {
            _txtTitle.text = "You Win";
            _txtCannotReceiveReward.gameObject.SetActive(false);
        }
        else
        {
            _txtTitle.text = "You Lose";
            _txtCannotReceiveReward.gameObject.SetActive(true);
        }

        // create explorer
        AssetReferenceT<GameObject> explorerRef = _explorerManager.GetExplorerModelRef(_runtimeGlobalData.DataStartGamePlay.Explorer);
        AsyncOperationHandle<GameObject> loadHandle = Addressables.InstantiateAsync(explorerRef);

        await UniTask.WaitUntil(() => loadHandle.IsDone);
        if (loadHandle.Status == AsyncOperationStatus.Succeeded)
        {
            var explorerInstance = loadHandle.Result;
            explorerInstance = loadHandle.Result;

            explorerInstance.transform.position = _posSpawnExplorerDisplay.position;
        }

        // setup coin
        _txtCoin.text = _levelConfig.GetLevelData(_runtimeGlobalData.DataEndGame.LevelId).coinReward.ToString();

        // setup gem
        var gemObj = Instantiate(_levelConfig.GetLevelData(_runtimeGlobalData.DataEndGame.LevelId).treasureData.treasurePrefabRef, _posSpawnGemDisplay.position, Quaternion.identity);
    }
}
