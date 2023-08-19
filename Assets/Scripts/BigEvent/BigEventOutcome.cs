using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigEvent
{
    public class BigEventOutcome : EventOutcome
    {
        protected override void Awake()
        {
            base.Awake();
        }

        public override void OnNextButtonDown()
        {
            //todo 下一关
            EventCenter.Instance.EventTrigger("NextStage");
        }
    }
}

