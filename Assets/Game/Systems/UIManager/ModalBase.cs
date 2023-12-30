using UnityEngine;

public abstract class ModalBase : MonoBehaviour
{
    // abstract method OnClose, OnShow, AnimationEnd
    protected abstract void OnClose();
    protected abstract void OnShow();
    protected abstract void AnimationEnd();

    // method show modal
    public virtual void Show()
    {
        // call method OnShow
        gameObject.SetActive(true);
        OnShow();
    }

    public virtual void Close()
    {
        // call method OnClose
        gameObject.SetActive(false);
        OnClose();
    }
}
