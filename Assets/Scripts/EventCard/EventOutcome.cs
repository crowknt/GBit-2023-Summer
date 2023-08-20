using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EventOutcome : MonoBehaviour
{
    [SerializeField] protected Button nextButton;
    [SerializeField] protected Image image;
    [SerializeField] protected TextMeshProUGUI info;
    [SerializeField] protected TextMeshProUGUI buttonText;

    protected virtual void Awake()
    {
        nextButton.onClick.AddListener(OnNextButtonDown);
    }

    public virtual void OnNextButtonDown()
    {
        //todo switch to next event
        //EventCenter.Instance.EventTrigger("TestResetEvent");
        EventCenter.Instance.EventTrigger("NextSmallEvent");
        EventCenter.Instance.EventTrigger("CloseTextAbilityStatus");
    }

    public void ChangeOutcomeInfo(Sprite newImg, string newInfo, string newButtonText)
    {
        image.sprite = newImg;
        info.text = newInfo;
        buttonText.text = newButtonText;
        
        //todo 也许在这里换事件
    }
}
