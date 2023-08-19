using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventOutcome : MonoBehaviour
{
    [SerializeField] private Button nextButton;

    private void Awake()
    {
        if (nextButton.onClick.GetPersistentEventCount() == 0)
        {
            nextButton.onClick.AddListener(OnNextButtonDown);
        }
    }

    public void OnNextButtonDown()
    {
        //todo switch to next event
        EventCenter.Instance.EventTrigger("TestResetEvent");
    }
}
