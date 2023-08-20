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
        
    }

    public void OnLeftButtonDown()
    {
        eventCard.SetActive(false);
        leftOutcome.gameObject.SetActive(true);
        leftOutcome.RunPrinter();
        //todo switch to left outcome
    }

    public void OnRightButtonDown()
    {
        //todo switch to right outcome
        eventCard.SetActive(false);
        rightOutcome.gameObject.SetActive(true);
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
    
    /// <summary>
    /// 工作日切换至休息日的动效，从无到有
    /// </summary>
    private void NextSmallEventEffect()
    {
        
    }
    /// <summary>
    /// 休息日到对应工作日的动效，从有到无
    /// </summary>
    private void SwitchToOutcomeEffect()
    {
        
    }
}
