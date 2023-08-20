using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BigEvent
{
    public class BigEvent : MonoBehaviour
    {
        [Header("条件"), SerializeField] protected int intelligenceCondition = 10;
        [SerializeField] protected int virtueCondition = 10;
        [SerializeField] protected int bodyCondition = 10;
        [Header("显示内容"), SerializeField] private Image img;
        [SerializeField] private TextMeshProUGUI info;
        [SerializeField] private TextMeshProUGUI buttonText;
        [Header("按钮")]
        [SerializeField] protected Button checkButton;
        [Header("内容控制")]
        [SerializeField] protected GameObject bigEvent;
        [SerializeField] protected BigEventOutcome yesOutcome;
        [SerializeField] protected BigEventOutcome noOutcome;
        [Header("数据")] [SerializeField] protected PlayerAbilityData abilityData;
        [SerializeField] private AudioClip clip;

        private BigEventData _bigEventData;
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

            if (clip != null)
            {
                SoundManager.PlaySoundEffect(clip);
            }
            
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

        public void UpdateBigEventData(BigEventData newData)
        {
            _bigEventData = newData;

            intelligenceCondition = newData.intelligenceCondition;
            virtueCondition = newData.virtueCondition;
            bodyCondition = newData.bodyCondition;

            img.sprite = newData.image;
            info.text = newData.info;
            buttonText.text = newData.buttonText;
            
            yesOutcome.UpdateOutcomeInfo(newData.yesOutcome);
            noOutcome.UpdateOutcomeInfo(newData.noOutcome);
        }
    }

}
