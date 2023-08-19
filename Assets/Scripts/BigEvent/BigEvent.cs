using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BigEvent
{
    public class BigEvent : MonoBehaviour
    {
        [Header("条件"), SerializeField] protected int intelligenceCondition = 10;
        [SerializeField] protected int virtueCondition = 10;
        [SerializeField] protected int bodyCondition = 10;
        [SerializeField] protected Button checkButton;
        [SerializeField] protected GameObject bigEvent;
        [SerializeField] protected EventOutcome yesOutcome;
        [SerializeField] protected EventOutcome noOutcome;

        protected virtual void Awake()
        {
            if (checkButton.onClick.GetPersistentEventCount() == 0)
            {
                checkButton.onClick.AddListener(OnCheckButton);
            }
        }

        protected void Start()
        {
            bigEvent.SetActive(true);
            yesOutcome.gameObject.SetActive(false);
            noOutcome.gameObject.SetActive(false);
        }

        protected virtual void OnCheckButton()
        {
            //todo 检测人物属性值
            
            
            bigEvent.SetActive(false);
            //todo if 不通过
            yesOutcome.gameObject.SetActive(true);
            //todo if 通过
            //noOutcome.gameObject.SetActive(true);
        }
    }

}
