using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EventChooseButton : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    [SerializeField,Tooltip("智力")] private int intelligenceChange = 0;
    [SerializeField,Tooltip("美德")] private int virtueChange = 0;
    [SerializeField,Tooltip("身体")] private int bodyChange = 0;
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        
        _button.onClick.AddListener(OnEventButtonDown);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("mouse enter");
        // todo : Do mark highlight
        if (intelligenceChange != 0)
        {
            
        }

        if (virtueChange != 0)
        {
            
        }

        if (bodyChange != 0)
        {
            
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //todo : reset mark highlight
        if (intelligenceChange != 0)
        {
            
        }

        if (virtueChange != 0)
        {
            
        }

        if (bodyChange != 0)
        {
            
        }
    }

    public void OnEventButtonDown()
    {
        //todo: change value
        
        EventCenter.Instance.EventTrigger<int,int,int>("AbilityDataChange",intelligenceChange,virtueChange,bodyChange);
    }
}
