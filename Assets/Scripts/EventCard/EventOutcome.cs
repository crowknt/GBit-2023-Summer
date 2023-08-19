using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventOutcome : MonoBehaviour
{
    [SerializeField] protected Button nextButton;

    protected virtual void Awake()
    {
        if (nextButton.onClick.GetPersistentEventCount() == 0)
        {
            nextButton.onClick.AddListener(OnNextButtonDown);
        }
    }

    public virtual void OnNextButtonDown()
    {
        //todo switch to next event
        //EventCenter.Instance.EventTrigger("TestResetEvent");
        EventCenter.Instance.EventTrigger("NextSmallEvent");
        EventCenter.Instance.EventTrigger("CloseTextAbilityStatus");
    }
}
