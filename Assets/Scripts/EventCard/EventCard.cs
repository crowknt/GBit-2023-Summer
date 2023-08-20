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
<<<<<<< HEAD
    [Header("左按钮数值")] [SerializeField] private int leftIntelligence = 0;
    [SerializeField] private int leftVirtue = 0;
    [SerializeField] private int leftBody = 0;
    [Header("右按钮数值")][SerializeField] private int rightIntelligence = 0;
    [SerializeField] private int rightVirtue = 0;
    [SerializeField] private int rightBody = 0;
=======
    [Header("数值")] [SerializeField] private EventData eventData;

    [Header("事件的显示模块")] [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI info;
    
>>>>>>> 6162d725ffc1cd009b27901455e6f3e86d791796


    private EventChooseButton _leftButtonScript;
    private EventChooseButton _rightButtonScript;
<<<<<<< HEAD
=======

    private EventData.EventCardInfo _currentEventCardInfo;
>>>>>>> 6162d725ffc1cd009b27901455e6f3e86d791796
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
<<<<<<< HEAD
        EventCenter.Instance.AddListener("TestResetEvent",TestResetEvent);
        
        _leftButtonScript.InitialValueChangeData(leftIntelligence,leftVirtue,leftBody);
        _rightButtonScript.InitialValueChangeData(rightIntelligence,rightVirtue,rightBody);
=======
        
>>>>>>> 6162d725ffc1cd009b27901455e6f3e86d791796
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
