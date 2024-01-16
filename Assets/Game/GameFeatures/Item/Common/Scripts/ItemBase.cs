using System;
using UnityEngine;

[Serializable]
public abstract class ItemBase : MonoBehaviour
{
    // create abstract method Use
    public abstract void Use(Transform explorerTransform);

    // create abstract method Upgrade
    public abstract void Upgrade();

}
