using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BigEvent;

namespace Manager.Stage
{
    public class StageManager : MonoBehaviour
    {
        [SerializeField,Tooltip("关卡序号")] private int stageCount = 0;
        [SerializeField, Tooltip("关卡名")] private string stageName = "";
        [SerializeField] private string nextStageName = "";
        [SerializeField] private List<EventCard> eventCards;
        [SerializeField] private BigEvent.BigEvent bigEvent;

        public int EventCount => eventCards.Count;

        private EventCard _currentEvent;
        private int _currentEventIndex = 0;
        private BigEvent.BigEvent _bigEvent;
        private void Awake()
        {
            //todo add event change event
            EventCenter.Instance.AddListener("NextSmallEvent",NextSmallEvent);
            EventCenter.Instance.AddListener("NextStage",NextStage);
        }

        private void Start()
        {
            _currentEvent = Instantiate(eventCards[0], transform);
        }

        private void NextSmallEvent()
        {
            if (EventCount <= 1)
            {
                
                //todo 大事件和大事件检定
                if (bigEvent != null)
                {
                    _bigEvent = Instantiate(bigEvent, transform);
                }
                
                //清除当前事件
                Destroy(_currentEvent.gameObject);
                _currentEvent = null;
                eventCards.Remove(eventCards[0]);
                
                //进行大事件检定
                
                return;
            }
            Destroy(_currentEvent.gameObject);
            _currentEvent = Instantiate(eventCards[1], transform);
            eventCards.Remove(eventCards[0]);

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
        }
    }
}

