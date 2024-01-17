using UnityEngine.UI;
using UnityEngine;
using TMPro;
using DG.Tweening;
using SuperMaxim.Messaging;
using System;

public class SkillUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Image imgIcon;
    [SerializeField] private Image imgCoolDown;
    [SerializeField] private TMP_Text txtCountDown;

    private void Awake()
    {
        Messenger.Default.Subscribe<SkillPerformingMessage>(OnUpdateSkillCountDown);
    }

    private void OnUpdateSkillCountDown(SkillPerformingMessage message)
    {
        if(message.PercentCountDown <= 0)
        {
            imgCoolDown.fillAmount = 0;
            imgCoolDown.gameObject.SetActive(false);

            txtCountDown.text = "";
            txtCountDown.gameObject.SetActive(false);
            return;
        }
        else
        {
            imgCoolDown.gameObject.SetActive(true);
            txtCountDown.gameObject.SetActive(true);

            imgCoolDown.DOFillAmount(message.PercentCountDown, 1f);
            txtCountDown.text = message.PercentCountDown.ToString("0.0");
        }
    }

    // setup UI
    public void SetupUI(Sprite icon)
    {
        imgIcon.sprite = icon;
        imgCoolDown.fillAmount = 0;
    }

    public void CountDownTimeSkill(float time)
    {
        if(time <= 0)
        {
            imgCoolDown.fillAmount = 0;
            imgCoolDown.gameObject.SetActive(false);

            txtCountDown.text = "";
            txtCountDown.gameObject.SetActive(false);
            return;
        }
        else
        {
            imgCoolDown.gameObject.SetActive(true);
            txtCountDown.gameObject.SetActive(true);

            imgCoolDown.DOFillAmount(time, 0.5f);
            txtCountDown.text = time.ToString("0.0");
        }
    }
}
