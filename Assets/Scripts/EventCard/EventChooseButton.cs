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

    private void Start()
    {
        HideOnInstantiate();
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

    /// <summary>
    /// 页面切换不在此处，此处仅含高亮，ui内容更新，和数值更新
    /// </summary>
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
        // _stageManager.smallEventState = StageManager.SmallEventState.Outcome;
        //Debug.Log("选择按钮");
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
    
    //!!!
    //

    /// <summary>
    /// 切换到工作日时的淡出
    /// </summary>
    public void FadeOutEffect()
    {
        
    }

    /// <summary>
    /// 切换到休息日时的淡入
    /// </summary>
    public void FadeInEffect()
    {
        
    }

    public void HideOnInstantiate()
    {
        
    }
}
