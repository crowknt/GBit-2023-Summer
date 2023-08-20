using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EventChooseButton : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    private int intelligenceChange = 0;
    private int virtueChange = 0;
    private int bodyChange = 0;
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        
        _button.onClick.AddListener(OnEventButtonDown);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
        if (intelligenceChange != 0)
        {
            EventCenter.Instance.EventTrigger("IntelligenceHighlight");
        }

        if (virtueChange != 0)
        {
            EventCenter.Instance.EventTrigger("VirtueHighlight");
        }

        if (bodyChange != 0)
        {
            EventCenter.Instance.EventTrigger("BodyHighlight");
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        EventCenter.Instance.EventTrigger("ClearHighlights");
    }

    public void OnEventButtonDown()
    {
        EventCenter.Instance.EventTrigger<int,int,int>("AbilityDataChange",intelligenceChange,virtueChange,bodyChange);
        EventCenter.Instance.EventTrigger("SliderFillChange");
        EventCenter.Instance.EventTrigger("ShowWeekday");
        EventCenter.Instance.EventTrigger("ShowTextAbilityStatus");
    }

    public void InitialValueChangeData(int intelligence,int virtue,int body)
    {
        intelligenceChange = intelligence;
        virtueChange = virtue;
        bodyChange = body;
    }
}
