using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BigEvent;
using UnityEngine.Serialization;

namespace Manager.Stage
{
    public class StageManager : MonoBehaviour
    {
        [SerializeField,Tooltip("关卡序号")] private int stageCount = 0;
        [SerializeField, Tooltip("关卡名")] private string stageName = "";
        [SerializeField] private string nextStageName = "";
        [Header("事件数据")] [SerializeField] private EventData eventData;
        [SerializeField] private EventCard _eventCard;
        
        [SerializeField] private BigEvent.BigEvent bigEvent;

        [FormerlySerializedAs("textAbilityUI")] [Header("文字属性显示")] [SerializeField] private GameObject textAbilityStatus;
        [Header("属性数据")] [SerializeField] private PlayerAbilityData abilityData;

        [SerializeField, Header("结局弹窗")] private GameOverPopupController gameOverPop;

        private EventData.EventCardInfo _curEventCardInfo;
        private int _currentEventIndex = 0;
        private int _remainingEvents = 0;
        private BigEvent.BigEvent _bigEvent;
        private TextualStats _textualStats;
        private GameOverPopupController _gameOverPop;
        private void Awake()
        {
            //todo add event change event
            EventCenter.Instance.AddListener("NextSmallEvent",NextSmallEvent);
            EventCenter.Instance.AddListener("NextStage",NextStage);
            EventCenter.Instance.AddListener("CloseTextAbilityStatus",CloseTextAbilityStatus);
            EventCenter.Instance.AddListener("ShowTextAbilityStatus",ShowTextAbilityStatus);
            EventCenter.Instance.AddListener<string>("SpecialEnd",SmallOutcomeButtonSpecial);

            _textualStats = textAbilityStatus.GetComponent<TextualStats>();
        }

        private void Start()
        {
            _curEventCardInfo = eventData.eventCardInfos[0];
            _currentEventIndex = 0;
            _remainingEvents = eventData.eventCardInfos.Count - 1;
            _eventCard.ResetEvent(_curEventCardInfo);
            EventCenter.Instance.EventTrigger<int>("ShowRemainingDaysOff",_remainingEvents);
            EventCenter.Instance.EventTrigger("ClearHighlights");
            CloseTextAbilityStatus();
        }

        public void NextSmallEvent()
        {
            if (_remainingEvents < 1 || _currentEventIndex == eventData.eventCardInfos.Count)
            {
                _eventCard.gameObject.SetActive(false);
                _bigEvent = Instantiate(bigEvent, transform);
                return;
            }

            _currentEventIndex += 1;
            _curEventCardInfo = eventData.eventCardInfos[_currentEventIndex];
            _remainingEvents--;
            _eventCard.ResetEvent(_curEventCardInfo);
            EventCenter.Instance.EventTrigger<int>("ShowRemainingDaysOff",_remainingEvents);

        }

        private void NextStage()
        {
            //todo change scene to next stage
            Debug.Log("下一关");
        }

        private void OnDestroy()
        {
            EventCenter.Instance.RemoveEventListener("NextSmallEvent",NextSmallEvent);
            EventCenter.Instance.RemoveEventListener("NextStage",NextStage);
            EventCenter.Instance.RemoveEventListener("CloseTextAbilityStatus",CloseTextAbilityStatus);
            EventCenter.Instance.RemoveEventListener("ShowTextAbilityStatus",ShowTextAbilityStatus);
        }

        private void ShowTextAbilityStatus()
        {
            textAbilityStatus.SetActive(true);

            _textualStats.Intelligence = abilityData.intelligence;
            _textualStats.Virtue = abilityData.virtue;
            _textualStats.Health = abilityData.body;
        }

        private void CloseTextAbilityStatus()
        {
            textAbilityStatus.SetActive(false);
        }

        public void SmallOutcomeButton()
        {
            
        }

        public void SmallOutcomeButtonSpecial(string specialText)
        {
            _gameOverPop = Instantiate(gameOverPop, transform);
            _gameOverPop.SpecialEndTextChange(specialText);
        }
    }
}

