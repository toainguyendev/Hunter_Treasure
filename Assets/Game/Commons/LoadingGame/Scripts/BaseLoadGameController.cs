
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseLoadGameController : ScriptableObject
{
    [SerializeField] protected List<UniTask> tasksWhenLoadGame;

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
