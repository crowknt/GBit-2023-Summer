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
<<<<<<< HEAD

        public int EventCount
        {
            get
            {
                if (eventCards == null)
                {
                    return 0;
                }

                return eventCards.Count;
            }
        }
=======
>>>>>>> 6162d725ffc1cd009b27901455e6f3e86d791796


        private EventData.EventCardInfo _curEventCardInfo;
        private int _currentEventIndex = 0;
        private int _remainingEvents = 0;
        private BigEvent.BigEvent _bigEvent;
        private TextualStats _textualStats;
        private void Awake()
        {
            //todo add event change event
            EventCenter.Instance.AddListener("NextSmallEvent",NextSmallEvent);
            EventCenter.Instance.AddListener("NextStage",NextStage);
            EventCenter.Instance.AddListener("CloseTextAbilityStatus",CloseTextAbilityStatus);
            EventCenter.Instance.AddListener("ShowTextAbilityStatus",ShowTextAbilityStatus);
<<<<<<< HEAD
=======
            EventCenter.Instance.AddListener<string>("SpecialEnd",SmallOutcomeButtonSpecial);
>>>>>>> 6162d725ffc1cd009b27901455e6f3e86d791796

            _textualStats = textAbilityStatus.GetComponent<TextualStats>();
        }

        private void Start()
        {
<<<<<<< HEAD
            _currentEvent = Instantiate(eventCards[0], transform);
            EventCenter.Instance.EventTrigger<int>("ShowRemainingDaysOff",eventCards.Count);
=======
            _curEventCardInfo = eventData.eventCardInfos[0];
            _currentEventIndex = 0;
            _remainingEvents = eventData.eventCardInfos.Count - 1;
            _eventCard.ResetEvent(_curEventCardInfo);
            EventCenter.Instance.EventTrigger<int>("ShowRemainingDaysOff",_remainingEvents);
>>>>>>> 6162d725ffc1cd009b27901455e6f3e86d791796
            EventCenter.Instance.EventTrigger("ClearHighlights");
            CloseTextAbilityStatus();
        }

        public void NextSmallEvent()
        {
<<<<<<< HEAD
            if (eventCards == null)
            {
                return;
            }
            
            if (EventCount == 1)
            {
                
                
                //进行大事件检定
                if (bigEvent != null)
                {
                    _bigEvent = Instantiate(bigEvent, transform);
                }
                
                //清除当前事件
                Destroy(_currentEvent.gameObject);
                _currentEvent = null;
                //eventCards.Remove(eventCards[0]);
                EventCenter.Instance.EventTrigger<int>("ShowRemainingDaysOff",0);
                
                
                
                return;
            }
            Destroy(_currentEvent.gameObject);
            _currentEvent = Instantiate(eventCards[1], transform);
            eventCards.Remove(eventCards[0]);
            EventCenter.Instance.EventTrigger<int>("ShowRemainingDaysOff",eventCards.Count);
=======
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
>>>>>>> 6162d725ffc1cd009b27901455e6f3e86d791796

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
<<<<<<< HEAD
=======
        }

        public void SmallOutcomeButton()
        {
            
        }

        public void SmallOutcomeButtonSpecial(string specialText)
        {
            
>>>>>>> 6162d725ffc1cd009b27901455e6f3e86d791796
        }
    }
}

