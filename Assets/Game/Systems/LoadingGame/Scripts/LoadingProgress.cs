using DG.Tweening;
using SuperMaxim.Messaging;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// struct payload to publish, subcribe event progress
public struct LoadingProgressPayload
{
    public float progress;
}

public class LoadingProgress : MonoBehaviour
{
    // serialize private image to show progress
    [SerializeField] private Image progressImage;

    // text to show percent
    [SerializeField] private TMP_Text percentText;

    // duration time to fill progress image
    [SerializeField] private float durationFillProgress = 0.5f;


    private void Awake()
    {
        progressImage.fillAmount = 0;
        percentText.SetText("0%");

        Messenger.Default.Subscribe<LoadingProgressPayload>(UpdateProgress);
    }


    // Upgrade this function to show progress
    public void UpdateProgress(LoadingProgressPayload progressPayload)
    {
        progressImage.DOFillAmount(progressPayload.progress, durationFillProgress);
        percentText.SetText($"{progressPayload.progress * 100}%");
    }

    private void OnDestroy()
    {
        Messenger.Default.Unsubscribe<LoadingProgressPayload>(UpdateProgress);
    }
}
