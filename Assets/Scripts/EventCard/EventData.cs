using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("Data/EventData"), fileName = ("EventData"))]
public class EventData : ScriptableObject
{
   [Serializable]
   public class EventCardInfo
   {
      [Tooltip("第几关")]public int stageID = 0;
      [Tooltip("关卡内第几个，可能没用")] public int eventNum = 1;
      [Tooltip("事件图片")] public Sprite image;
      [Tooltip("事件内容"),TextArea(3,4)] public string info;
      [Header("左选择")] public EventOutcomeInfo outcomeInfoL;
      [Header("右选择")] public EventOutcomeInfo outcomeInfoR;

   }
   [Serializable]
   public class EventOutcomeInfo
   {
      [Header("属性数值变化")] public int intelligence;
      public int virtue;
      public int body;

      [Header("事件结果信息")] public Sprite image;
      [TextArea(3,4)]public string info;

      [Header("按钮文字")] [Tooltip("休息日界面的选择按钮")]
      public string chooseButtonText = "yes";

      [Tooltip("工作日界面的继续按钮")] public string continueButtonText = "下个休息日";

      [Header("特殊事件相关")] [Tooltip("是否特殊工作日事件，触发后结束（如掐死自己）")]
      public bool isEndEvent;

      [TextArea(3,4)]public string specialEndText = "你阻止了自己出生，赢了太多";

      [Header("特殊背景音乐")] public AudioClip backgroundMusic;
   }

   public int stageID = 0;
   public List<EventCardInfo> eventCardInfos = new List<EventCardInfo>();
   
}
