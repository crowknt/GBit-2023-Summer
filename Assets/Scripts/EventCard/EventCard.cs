using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventCard : MonoBehaviour
{
    [SerializeField] private GameObject eventCard;
    [SerializeField] private EventOutcome leftOutcome;
    [SerializeField] private EventOutcome rightOutcome;
    [Header("选项")]
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;
    [Header("左按钮数值")] [SerializeField] private int leftIntelligence = 0;
    [SerializeField] private int leftVirtue = 0;
    [SerializeField] private int leftBody = 0;
    [Header("右按钮数值")][SerializeField] private int rightIntelligence = 0;
    [SerializeField] private int rightVirtue = 0;
    [SerializeField] private int rightBody = 0;


    private EventChooseButton _leftButtonScript;
    private EventChooseButton _rightButtonScript;
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
        EventCenter.Instance.AddListener("TestResetEvent",TestResetEvent);
        
        _leftButtonScript.InitialValueChangeData(leftIntelligence,leftVirtue,leftBody);
        _rightButtonScript.InitialValueChangeData(rightIntelligence,rightVirtue,rightBody);
    }

    public void OnLeftButtonDown()
    {
        eventCard.SetActive(false);
        leftOutcome.gameObject.SetActive(true);
        //todo switch to left outcome
    }

    public void OnRightButtonDown()
    {
        Debug.Log("right button down");
        //todo switch to right outcome
        eventCard.SetActive(false);
        rightOutcome.gameObject.SetActive(true);
    }

    private void TestResetEvent()
    {
        leftOutcome.gameObject.SetActive(false);
        rightOutcome.gameObject.SetActive(false);
        eventCard.SetActive(true);
    }

    
}
