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
   
    
    private void Awake()
    {
        
        leftButton.onClick.AddListener(OnLeftButtonDown);
        rightButton.onClick.AddListener(OnRightButtonDown);
        
        leftOutcome.gameObject.SetActive(false);
        rightOutcome.gameObject.SetActive(false);
        eventCard.SetActive(true);
        
    }

    private void Start()
    {
        EventCenter.Instance.AddListener("TestResetEvent",TestResetEvent);
    }

    public void OnLeftButtonDown()
    {
        Debug.Log("left button down");
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
