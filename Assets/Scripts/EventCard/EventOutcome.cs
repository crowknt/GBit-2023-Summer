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
            FadeOutEffect();
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
        //info.text = newOutcome.info;
        info.text = "";
        _printContent = newOutcome.info;
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
        FadeOutEffect();
        _stageManager.smallEventState = StageManager.SmallEventState.Card;
        EventCenter.Instance.EventTrigger("NextSmallEvent");
       
    }
    
    [Header("打字特效")] [SerializeField] private float printSpeed = 15;
    private string _printContent;
    private void PrintText(string textToPrint, TextMeshProUGUI textLabel)
    {
        StartCoroutine(PrintTextRoutine(textToPrint, textLabel));
    }

    IEnumerator PrintTextRoutine(string textToPrint, TextMeshProUGUI textLabel)
    {
        float t = 0;
        int charIndex = 0;
        while (charIndex < textToPrint.Length)
        {
            t += Time.deltaTime * printSpeed;
            charIndex = Mathf.FloorToInt(t);//把t转为int类型赋值给charIndex
            charIndex = Mathf.Clamp(charIndex, 0, textToPrint.Length);
            textLabel.text = textToPrint.Substring(0, charIndex);

            yield return null;
        }
        textLabel.text = textToPrint;
    }

    public void RunPrinter()
    {
        PrintText(_printContent,info);
    }

    /// <summary>
    /// 事件结果的按钮没有特别的逻辑（鼠标高亮事件），所以没有分开。按钮的引用都在这里
    /// </summary>
    public void FadeInEffect()
    {
        
    }

    /// <summary>
    /// 特殊结局时应该没特别问题。普通情况下在协程DelayedSwitch里调用（我已经调了），协程的延迟用于避免额外的按钮触发
    /// </summary>
    public void FadeOutEffect()
    {
        
    }
}
