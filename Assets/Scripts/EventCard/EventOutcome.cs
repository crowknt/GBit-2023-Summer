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

    [SerializeField] private AudioClip clip;
    // [SerializeField] protected StageManager stageManager;

    private bool isSpecial = false;
    private string _specialText = "";
    private StageManager _stageManager;
    protected virtual void Awake()
    {
        nextButton.onClick.AddListener(OnNextButtonDown);
        // if (stageManager == null)
        // {
        //     stageManager = transform.GetComponentInParent<StageManager>();
        // }
        _stageManager = GetComponentInParent<StageManager>();
    }

    public virtual void OnNextButtonDown()
    {
        if (clip != null)
        {
            SoundManager.PlaySoundEffect(clip);
        }
        
        //todo switch to next event
        //EventCenter.Instance.EventTrigger("TestResetEvent");
        if (isSpecial)
        {
            //Debug.Log("特殊事件");
            EndEvent(_specialText);
            return;
        }

        
        Debug.Log("结束按钮");
        StartCoroutine(DelayedSwtich());

       
        //EventCenter.Instance.EventTrigger("CloseTextAbilityStatus");

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

    private IEnumerator DelayedSwtich()
    {
        
        
        yield return new WaitForSeconds(0.2f);
        
        _stageManager.smallEventState = StageManager.SmallEventState.Card;
        EventCenter.Instance.EventTrigger("NextSmallEvent");
       
    }
    
}
