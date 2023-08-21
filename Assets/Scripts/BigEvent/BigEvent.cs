using System;
using System.Collections;
using System.Collections.Generic;
using Manager;
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
        [Header("动效")] [SerializeField] private CanvasGroup mainUI;
        [SerializeField] private CardController card;
        
        private BigEventData _bigEventData;
        protected virtual void Awake()
        {
            if (checkButton.onClick.GetPersistentEventCount() == 0)
            {
                checkButton.onClick.AddListener(OnCheckButton);
            }

            EventCenter.Instance.AddListener<float>(Const.Events.ChangeMainUIOpacity, ChangeMainUIOpacity);
        }

        protected void Start()
        {
            bigEvent.SetActive(true);
            yesOutcome.gameObject.SetActive(false);
            noOutcome.gameObject.SetActive(false);
            
        }

        private void OnDestroy()
        {
            EventCenter.Instance.RemoveEventListener<float>(Const.Events.ChangeMainUIOpacity, ChangeMainUIOpacity);
        }

        protected virtual void OnCheckButton()
        {
            StartCoroutine(RunOnCheckButton());
        }

        private IEnumerator RunOnCheckButton()
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
                yield return FadeOutEffect();

                noOutcome.gameObject.SetActive(true);

                yield return noOutcome.FadeInEffect();
                noOutcome.RunPrinter();
                yield break;
            }

            //通过
            yield return FadeOutEffect();

            yesOutcome.gameObject.SetActive(true);
            yield return yesOutcome.FadeInEffect();
            yesOutcome.RunPrinter();
        }

        public void UpdateBigEventData(BigEventData newData)
        {
            _bigEventData = newData;

            intelligenceCondition = newData.intelligenceCondition;
            virtueCondition = newData.virtueCondition;
            bodyCondition = newData.bodyCondition;

            img.sprite = newData.image;
            _printContent = newData.info;
            //info.text = newData.info;
            info.text = "";
            PrintText(_printContent,info);
            buttonText.text = newData.buttonText;
            
            yesOutcome.UpdateOutcomeInfo(newData.yesOutcome);
            noOutcome.UpdateOutcomeInfo(newData.noOutcome);
        }

        [Header("打字特效")] [SerializeField] private float printSpeed = 15;
        private string _printContent;
        private void PrintText(string textToPrint, TextMeshProUGUI textLabel)
        {
            StartCoroutine(PrintTextRoutine(textToPrint, textLabel));
        }

        IEnumerator PrintTextRoutine(string textToPrint, TextMeshProUGUI textLabel)
        {
            float t = 0;
            int charIndex = 0;
            while (charIndex < textToPrint.Length)
            {
                t += Time.deltaTime * printSpeed;
                charIndex = Mathf.FloorToInt(t);//把t转为int类型赋值给charIndex
                charIndex = Mathf.Clamp(charIndex, 0, textToPrint.Length);
                textLabel.text = textToPrint.Substring(0, charIndex);

                yield return null;
            }
            textLabel.text = textToPrint;
        }

        public IEnumerator FadeInEffect()
        {
            EventCenter.Instance.EventTrigger(Const.Events.ChangeMainUIOpacity, 0f);
            yield return StartCoroutine(card.FlipOn());
            yield return StartCoroutine(UIManager.FadeInMainUI());
        }

        public IEnumerator FadeOutEffect()
        {
            yield return StartCoroutine(UIManager.FadeOutMainUI());
            yield return StartCoroutine(card.FlipOff());
        }

        /// <summary>
        /// 大事件是先实例化，所以考虑先隐藏
        /// </summary>
        public void HideOnInstantiate()
        {
            
        }

        private void ChangeMainUIOpacity(float opacity)
        {
            mainUI.alpha = opacity;
        }
    }

}
