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
        [Header("按钮")]
        [SerializeField] protected Button checkButton;
        [Header("内容")]
        [SerializeField] protected GameObject bigEvent;
        [SerializeField] protected EventOutcome yesOutcome;
        [SerializeField] protected EventOutcome noOutcome;
        [Header("数据")] [SerializeField] protected PlayerAbilityData abilityData;

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
            //关闭当前窗口
            bigEvent.SetActive(false);
            
            //检测属性值
            if (abilityData.intelligence < intelligenceCondition || abilityData.virtue < virtueCondition ||
                abilityData.body < bodyCondition)
            {
                //不通过
                
                noOutcome.gameObject.SetActive(true);
                return;
            }
            //通过
            yesOutcome.gameObject.SetActive(true);
        }
    }

}
