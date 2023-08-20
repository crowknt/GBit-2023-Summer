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
        //todo switch to left outcome
    }

    public void OnRightButtonDown()
    {
        //todo switch to right outcome
        eventCard.SetActive(false);
        rightOutcome.gameObject.SetActive(true);
    }

    public void ResetEvent(EventData.EventCardInfo newInfo)
    {
       ChangeCardInfo(newInfo.image,newInfo.info);
       _leftButtonScript.UpdateChooseInfo(newInfo.outcomeInfoL.intelligence,newInfo.outcomeInfoL.virtue,
           newInfo.outcomeInfoL.body,newInfo.outcomeInfoL.chooseButtonText);
       _rightButtonScript.UpdateChooseInfo(newInfo.outcomeInfoR.intelligence,newInfo.outcomeInfoR.virtue,
           newInfo.outcomeInfoR.body,newInfo.outcomeInfoR.chooseButtonText);
       
       
        leftOutcome.gameObject.SetActive(false);
        leftOutcome.UpdateOutcomeInfo(newInfo.outcomeInfoL);
        rightOutcome.UpdateOutcomeInfo(newInfo.outcomeInfoR);
        
        rightOutcome.gameObject.SetActive(false);
        eventCard.SetActive(true);
    }

    public void ChangeButtonInfo()
    {
        
    }

    public void ChangeCardInfo(Sprite newImg, string newInfo)
    {
        image.sprite = newImg;
        info.text = newInfo;
    }
}
