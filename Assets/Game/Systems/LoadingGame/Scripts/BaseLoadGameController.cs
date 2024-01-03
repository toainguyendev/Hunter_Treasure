
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public abstract class BaseLoadGameController : ScriptableObject
{
    [SerializeField] protected AssetReferenceT<GameObject>[] _preloadGameObjects;

    protected virtual async UniTask OnBeforeLoad()
    {
    }

    protected virtual async UniTask OnLoad()
    {
    }

    protected virtual async UniTask OnAfterLoad()
    {
    }

    public virtual async UniTask LoadGame()
    {
        await OnBeforeLoad();
        await OnLoad();
        await OnAfterLoad();    
    }
}
