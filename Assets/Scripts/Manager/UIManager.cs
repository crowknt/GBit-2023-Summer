using System;
using System.Collections;
using UnityEngine;

namespace Manager
{
    public class UIManager : MonoBehaviour
    {
        private static UIManager _instance;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            _instance = this;
        }

        public static IEnumerator FadeInMainUI()
        {
            if (_instance is null) yield break;
            EventCenter.Instance.EventTrigger(Const.Events.Block, true);
            {
                for (float elapsed = 0; elapsed <= Const.Timing.FadeIn;)
                {
                    float progress = elapsed / Const.Timing.FadeIn;
                    EventCenter.Instance.EventTrigger(Const.Events.ChangeMainUIOpacity, progress);
                    elapsed += Time.deltaTime;
                    yield return null;
                }

                EventCenter.Instance.EventTrigger(Const.Events.ChangeMainUIOpacity, 1f);
            }
            EventCenter.Instance.EventTrigger(Const.Events.Block, false);
        }


        public static IEnumerator FadeOutMainUI()
        {
            if (_instance is null) yield break;
            EventCenter.Instance.EventTrigger(Const.Events.Block, true);
            {
                for (float elapsed = 0; elapsed <= Const.Timing.FadeOut;)
                {
                    float progress = (Const.Timing.FadeOut - elapsed) / Const.Timing.FadeOut;
                    EventCenter.Instance.EventTrigger(Const.Events.ChangeMainUIOpacity, progress);
                    elapsed += Time.deltaTime;
                    yield return null;
                }

                EventCenter.Instance.EventTrigger(Const.Events.ChangeMainUIOpacity, 0f);
            }
            EventCenter.Instance.EventTrigger(Const.Events.Block, false);
        }
    }
}