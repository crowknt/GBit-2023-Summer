using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EventCard : MonoBehaviour
{
    [Header("显示的物体")]
    [SerializeField] private GameObject eventCard;
    [SerializeField] private EventOutcome leftOutcome;
    [SerializeField] private EventOutcome rightOutcome;
    [Header("选项")]
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;
    [Header("数值")] [SerializeField] private EventData eventData;

    [Header("事件的显示模块")] [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI info;
    


    private EventChooseButton _leftButtonScript;
    private EventChooseButton _rightButtonScript;

    private EventData.EventCardInfo _currentEventCardInfo;
    private void Awake()
    {
        
        leftButton.onClick.AddListener(OnLeftButtonDown);
        rightButton.onClick.AddListener(OnRightButtonDown);
        
        leftOutcome.gameObject.SetActive(false);
        rightOutcome.gameObject.SetActive(false);
        eventCard.SetActive(true);

        _leftButtonScript = leftButton.transform.GetComponent<EventChooseButton>();
        _rightButtonScript = rightButton.transform.GetComponent<EventChooseButton>();
    }

    private void Start()
    {
        HideOnInstantiate();
    }

    /// <summary>
    /// 此处，
    /// </summary>
    public void OnLeftButtonDown()
    {
        FadeOutEffect();
        
        eventCard.SetActive(false);
        leftOutcome.gameObject.SetActive(true);
        leftOutcome.FadeInEffect();
        leftOutcome.RunPrinter();
        
        
    }

    public void OnRightButtonDown()
    {
        FadeOutEffect();
        
        
        eventCard.SetActive(false);
        rightOutcome.gameObject.SetActive(true);
        rightOutcome.FadeInEffect();
        rightOutcome.RunPrinter();
    }

    public void ResetEvent(EventData.EventCardInfo newInfo)
    {
        
        leftOutcome.gameObject.SetActive(false);
        leftOutcome.UpdateOutcomeInfo(newInfo.outcomeInfoL);
        rightOutcome.UpdateOutcomeInfo(newInfo.outcomeInfoR);
        
        rightOutcome.gameObject.SetActive(false);
        eventCard.SetActive(true);
        _leftButtonScript.UpdateChooseInfo(newInfo.outcomeInfoL.intelligence,newInfo.outcomeInfoL.virtue,
            newInfo.outcomeInfoL.body,newInfo.outcomeInfoL.chooseButtonText);
        _rightButtonScript.UpdateChooseInfo(newInfo.outcomeInfoR.intelligence,newInfo.outcomeInfoR.virtue,
            newInfo.outcomeInfoR.body,newInfo.outcomeInfoR.chooseButtonText);
        
       ChangeCardInfo(newInfo.image,newInfo.info);
       
       FadeInEffect();
       
       PrintText(_printContent,info);
       
       
        
    }

    public void ChangeButtonInfo()
    {
        
    }

    public void ChangeCardInfo(Sprite newImg, string newInfo)
    {
        image.sprite = newImg;
        //info.text = newInfo;
        info.text = "";
        _printContent = newInfo;
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
    
    //!!!!
    
    //动效添加注意：
    //leftButton二者是休息日页面的按钮，_leftButtonScript是对应的按钮上绑的脚本
    //可能需要添加协程等
    //每个方法预设情况都是，内容已经更新完毕，执行完特效再显示出来
    
    /// <summary>
    /// 工作日切换至休息日的动效，从无到有。
    /// 会在每个新的scene自动执行第一次，所以大事件到小事件的后半部分动效通用此
    /// </summary>
    private void FadeInEffect()
    {
        //请见对应脚本
        _leftButtonScript.FadeInEffect();
        _rightButtonScript.FadeInEffect();
        
    }
    /// <summary>
    /// 休息日到对应工作日的动效，从有到无
    /// </summary>
    private void FadeOutEffect()
    {
        _leftButtonScript.FadeOutEffect();
        _rightButtonScript.FadeOutEffect();
    }

    /// <summary>
    /// 进入新scene时确保事件卡未显示出来
    /// </summary>
    private void HideOnInstantiate()
    {
        
    }
}
