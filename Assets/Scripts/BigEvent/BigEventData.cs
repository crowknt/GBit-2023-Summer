using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("Data/BigEventData"), fileName = ("BigEventData"))]
public class BigEventData : ScriptableObject
{
    [Header("条件")]
    public int intelligenceCondition;

    public int virtueCondition;
    public int bodyCondition;

    [Header("事件信息")] [Tooltip("事件描述"), TextArea(3, 4)]
    public string info;

    [Tooltip("事件图片")] public Sprite image;
    
    [Tooltip("检定按钮的文字")] public string buttonText = "check";

    [Header("通过")] public BigEventOutcomeInfo yesOutcome;
    [Header("不通过")] public BigEventOutcomeInfo noOutcome;
    
    
    [Serializable]
    public class BigEventOutcomeInfo
    {
        [TextArea(3,4)]public string info;
        public Sprite image;
        public string buttonText = "next";

        [Tooltip("这个事件分支是否接结局")] public bool isEnd;
    }

}
