using System;
using System.Collections;
using System.Collections.Generic;
using Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BigEvent
{
    public class BigEventOutcome : MonoBehaviour
    {
        [SerializeField] private Button nextButton;
        [SerializeField] private Image outcomeImage;
        [SerializeField] private TextMeshProUGUI info;
        [SerializeField] private TextMeshProUGUI buttonText;
        [SerializeField] private AudioClip clip;
        
        [Header("动效")] [SerializeField] private CanvasGroup mainUI;
        [SerializeField] private CardController card;

        private bool _isEnd = false;
        
        private void Awake()
        {
            nextButton.onClick.AddListener(OnNextButton);

            EventCenter.Instance.AddListener<float>(Const.Events.ChangeMainUIOpacity, ChangeMainUIOpacity);
        }

        private void OnDestroy()
        {
            EventCenter.Instance.RemoveEventListener<float>(Const.Events.ChangeMainUIOpacity, ChangeMainUIOpacity);
        }

        private void OnNextButton()
        {
            StartCoroutine(RunOnNextButton());
        }

        private IEnumerator RunOnNextButton()
        {
            if (clip != null)
            {
                SoundManager.PlaySoundEffect(clip);
            }

            if (_isEnd)
            {
                //todo 呼出结束窗口
                yield return StartCoroutine(FadeOutEffect());
                EventCenter.Instance.EventTrigger("NormalEnd");
                yield break;
            }

            yield return StartCoroutine(FadeOutEffect());
            //todo 下一关
            EventCenter.Instance.EventTrigger("NextStage");
        }

        public void UpdateOutcomeInfo(BigEventData.BigEventOutcomeInfo newInfo)
        {
            outcomeImage.sprite = newInfo.image;
            //info.text = newInfo.info;
            info.text = "";
            buttonText.text = newInfo.buttonText;
            _isEnd = newInfo.isEnd;
            _printContent = newInfo.info;
        }

        public void EndEvent()
        {
            
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

        public void RunPrinter()
        {
            PrintText(_printContent,info);
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

        private void ChangeMainUIOpacity(float opacity)
        {
            mainUI.alpha = opacity;
        }
    }
}

