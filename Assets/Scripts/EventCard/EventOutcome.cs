using System;
using System.Collections;
using System.Collections.Generic;
using Manager.Stage;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EventOutcome : MonoBehaviour
{
    [SerializeField] protected Button nextButton;
    [SerializeField] protected Image image;
    [SerializeField] protected TextMeshProUGUI info;
    [SerializeField] protected TextMeshProUGUI buttonText;
    // [SerializeField] protected StageManager stageManager;

    private bool isSpecial = false;
    private string _specialText = "";
    protected virtual void Awake()
    {
        nextButton.onClick.AddListener(OnNextButtonDown);
        // if (stageManager == null)
        // {
        //     stageManager = transform.GetComponentInParent<StageManager>();
        // }
    }

    public virtual void OnNextButtonDown()
    {
        //todo switch to next event
        //EventCenter.Instance.EventTrigger("TestResetEvent");
        if (isSpecial)
        {
            Debug.Log("特殊事件");
            EndEvent(_specialText);
            return;
        }
        
        EventCenter.Instance.EventTrigger("NextSmallEvent");
        
        
        EventCenter.Instance.EventTrigger("CloseTextAbilityStatus");
    }

    public void UpdateOutcomeInfo(EventData.EventOutcomeInfo newOutcome)
    {
        image.sprite = newOutcome.image;
        info.text = newOutcome.info;
        buttonText.text = newOutcome.continueButtonText;
        // nextButton.onClick.RemoveAllListeners();
        // nextButton.onClick.AddListener(OnNextButtonDown);
        if (!newOutcome.isEndEvent)
        {
            return;
        }
       
        isSpecial = newOutcome.isEndEvent;
        _specialText = newOutcome.specialEndText;
    }

    public void EndEvent(string specialText)
    {
        EventCenter.Instance.EventTrigger<string>("SpecialEnd",specialText);
    }
    
}
