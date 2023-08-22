using System;
using System.Collections;
using System.Collections.Generic;
using Manager;
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
    private AudioClip backgroundMusic;
    // [SerializeField] protected StageManager stageManager;
    
    [Header("动效")] [SerializeField] private CanvasGroup mainUI;
    [SerializeField] private CardController card;

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

        EventCenter.Instance.AddListener<float>(Const.Events.ChangeMainUIOpacity, ChangeMainUIOpacity);
    }

    private void OnEnable()
    {
        _stageManager.smallEventState = StageManager.SmallEventState.Outcome;
        if (backgroundMusic != null)
            SoundManager.SwitchBackgroundMusic(backgroundMusic);
    }

    private void OnDestroy()
    {
        EventCenter.Instance.RemoveEventListener<float>(Const.Events.ChangeMainUIOpacity, ChangeMainUIOpacity);
    }

    public virtual void OnNextButtonDown()
    {
        StartCoroutine(RunOnNextButtonDown());
    }

    private IEnumerator RunOnNextButtonDown()
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
            yield return StartCoroutine(FadeOutEffect());
            EndEvent(_specialText);
        }
        else
        {
            //Debug.Log("结束按钮");
            StartCoroutine(DelayedSwtich());

            //EventCenter.Instance.EventTrigger("CloseTextAbilityStatus");
        }
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
        backgroundMusic = newOutcome.backgroundMusic;
        if (!newOutcome.isEndEvent)
        {
            isSpecial = newOutcome.isEndEvent;
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
        yield return StartCoroutine(FadeOutEffect());
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
    public IEnumerator FadeInEffect()
    {
        EventCenter.Instance.EventTrigger(Const.Events.ChangeMainUIOpacity, 0f);
        yield return StartCoroutine(card.FlipOn());
        yield return StartCoroutine(UIManager.FadeInMainUI());

        RunPrinter();
    }

    /// <summary>
    /// 特殊结局时应该没特别问题。普通情况下在协程DelayedSwitch里调用（我已经调了），协程的延迟用于避免额外的按钮触发
    /// </summary>
    public IEnumerator FadeOutEffect()
    {
        yield return StartCoroutine(UIManager.FadeOutMainUI());
        yield return StartCoroutine(card.FlipOff());
    }

    private void ChangeMainUIOpacity(float opacity)
    {
        mainUI.alpha = opacity;
    }
}
