using System;
using System.Collections;
using System.Collections.Generic;
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

        private bool _isEnd = false;
        
        private void Awake()
        {
            nextButton.onClick.AddListener(OnNextButton);
        }

        private void OnNextButton()
        {
            if (clip != null)
            {
                SoundManager.PlaySoundEffect(clip);
            }
            
            if (_isEnd)
            {
                //todo 呼出结束窗口
                EventCenter.Instance.EventTrigger("NormalEnd");
                return;
            }

            //todo 下一关
            EventCenter.Instance.EventTrigger("NextStage");
        }

        public void UpdateOutcomeInfo(BigEventData.BigEventOutcomeInfo newInfo)
        {
            outcomeImage.sprite = newInfo.image;
            info.text = newInfo.info;
            buttonText.text = newInfo.buttonText;
            _isEnd = newInfo.isEnd;
        }

        public void EndEvent()
        {
            
        }
    }
}

