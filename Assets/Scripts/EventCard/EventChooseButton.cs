using System;
using System.Collections;
using System.Collections.Generic;
using Manager.Stage;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EventChooseButton : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    private int intelligenceChange = 0;
    private int virtueChange = 0;
    private int bodyChange = 0;
    private Button _button;
    [SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] private AudioClip clip;

    private StageManager _stageManager;
    private void Awake()
    {
        _button = GetComponent<Button>();
        
        _button.onClick.AddListener(OnEventButtonDown);
        _stageManager = GetComponentInParent<StageManager>();
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
        if (_stageManager.smallEventState == StageManager.SmallEventState.Outcome)
        {
            return;
        }
        if (clip != null)
        {
            SoundManager.PlaySoundEffect(clip);
        }
        //EventCenter.Instance.EventTrigger<int,int,int>("AbilityDataChange",intelligenceChange,virtueChange,bodyChange);
        GameManager.Instance.AbilityDataChange(intelligenceChange,virtueChange,bodyChange);
        EventCenter.Instance.EventTrigger("SliderFillChange");
        EventCenter.Instance.EventTrigger("ShowWeekday");
        //EventCenter.Instance.EventTrigger("ShowTextAbilityStatus");
        //EventCenter.Instance.EventTrigger("ShowTextStatus");
        _stageManager.smallEventState = StageManager.SmallEventState.Outcome;
        Debug.Log("选择按钮");
        EventCenter.Instance.EventTrigger("ClearHighlights");
        
    }

    public void InitialValueChangeData(int intelligence,int virtue,int body)
    {
        intelligenceChange = intelligence;
        virtueChange = virtue;
        bodyChange = body;
    }

    public void UpdateChooseInfo(int newIntelligence, int newVirtue, int newBody,string newText)
    {
        intelligenceChange = newIntelligence;
        virtueChange = newVirtue;
        bodyChange = newBody;
        buttonText.text = newText;
    }
}
