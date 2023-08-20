using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BigEvent;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Manager.Stage
{
    public class StageManager : MonoBehaviour
    {
        [SerializeField,Tooltip("关卡序号")] private int stageCount = 0;
        [SerializeField, Tooltip("关卡名")] private string stageName = "";
        [SerializeField] private string nextStageName = "空";
        [Header("事件数据")] [SerializeField] private EventData eventData;
        [SerializeField] private EventCard _eventCard;
        
        [Header("大事件")]
        [SerializeField] private BigEvent.BigEvent bigEvent;

        [SerializeField] private BigEventData bigEventData;
        
        [FormerlySerializedAs("textAbilityUI")] [Header("文字属性显示")] [SerializeField] private GameObject textAbilityStatus;
        [Header("属性数据")] [SerializeField] private PlayerAbilityData abilityData;
        //[SerializeField] private TextualStats textStatus;

        [SerializeField, Header("结局弹窗")] private GameOverPopupController gameOverPop;
        

        private EventData.EventCardInfo _curEventCardInfo;
        private int _currentEventIndex = 0;
        private int _remainingEvents = 0;
        private BigEvent.BigEvent _bigEvent;
        private TextualStats _textualStats;
        private GameOverPopupController _gameOverPop;

        public enum SmallEventState
        {
            Card,
            Outcome,
            BigEvent
        }

        public SmallEventState smallEventState = SmallEventState.Card;
        //private TextualStats _textStatus;
        private void Awake()
        {
            //todo add event change event
            EventCenter.Instance.AddListener("NextSmallEvent",NextSmallEvent);
            EventCenter.Instance.AddListener("NextStage",NextStage);
            EventCenter.Instance.AddListener("CloseTextAbilityStatus",CloseTextAbilityStatus);
            EventCenter.Instance.AddListener("ShowTextAbilityStatus",ShowTextAbilityStatus);
            EventCenter.Instance.AddListener<string>("SpecialEnd",SmallOutcomeButtonSpecial);
            EventCenter.Instance.AddListener("NormalEnd",NormalEnd);
            EventCenter.Instance.AddListener("ShowTextStatus",ShowTextStatus);

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

        private void Update()
        {
            switch (smallEventState)
            {
                case SmallEventState.Card:
                    CloseTextAbilityStatus();
                    break;
                case SmallEventState.Outcome:
                    ShowTextAbilityStatus();
                    break;
            }
        }

        public void NextSmallEvent()
        {
            if (_remainingEvents < 1 || _currentEventIndex == eventData.eventCardInfos.Count)
            {
                _eventCard.gameObject.SetActive(false);
                _bigEvent = Instantiate(bigEvent, transform);
                _bigEvent.UpdateBigEventData(bigEventData);
                return;
            }

            _currentEventIndex += 1;
            _curEventCardInfo = eventData.eventCardInfos[_currentEventIndex];
            _remainingEvents--;
            _eventCard.ResetEvent(_curEventCardInfo);
            EventCenter.Instance.EventTrigger<int>("ShowRemainingDaysOff",_remainingEvents);
            //_textualStats.gameObject.SetActive(false);
            //CloseTextStatus();

        }

        private void NextStage()
        {
            //todo change scene to next stage
            if (nextStageName == "空")
            {
                return;
            }

            SceneManager.LoadScene(nextStageName, LoadSceneMode.Single);
        }

        private void OnDestroy()
        {
            EventCenter.Instance.RemoveEventListener("NextSmallEvent",NextSmallEvent);
            EventCenter.Instance.RemoveEventListener("NextStage",NextStage);
            EventCenter.Instance.RemoveEventListener("CloseTextAbilityStatus",CloseTextAbilityStatus);
            EventCenter.Instance.RemoveEventListener("ShowTextAbilityStatus",ShowTextAbilityStatus);
            EventCenter.Instance.RemoveEventListener<string>("SpecialEnd",SmallOutcomeButtonSpecial);
            EventCenter.Instance.RemoveEventListener("NormalEnd",NormalEnd);
            EventCenter.Instance.RemoveEventListener("ShowTextStatus",ShowTextStatus);
        }

        public void ShowTextAbilityStatus()
        {
            textAbilityStatus.SetActive(true);

            _textualStats.Intelligence = abilityData.intelligence;
            _textualStats.Virtue = abilityData.virtue;
            _textualStats.Health = abilityData.body;
            
        }

        private void ShowTextStatus()
        {
            //_textStatus = Instantiate(textStatus, transform);
            //_textStatus.ChangeText(abilityData.intelligence,abilityData.virtue,abilityData.body);
        }

        public void CloseTextAbilityStatus()
        {
            textAbilityStatus.SetActive(false);
        }

        private void CloseTextStatus()
        {
            //Destroy(_textStatus);
        }

        public void SmallOutcomeButton()
        {
            
        }

        public void SmallOutcomeButtonSpecial(string specialText)
        {
            _gameOverPop = Instantiate(gameOverPop, transform);
            _gameOverPop.SpecialEndTextChange(specialText);
        }

        public void NormalEnd()
        {
            Debug.Log("大事件end event");
            _gameOverPop = Instantiate(gameOverPop, transform);
            _gameOverPop.ShowConclusion();
        }
    }
}

