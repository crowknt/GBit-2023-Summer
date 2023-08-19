using System;
using TMPro;
using UnityEngine;

public class DaysHint : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private string weekdayHint = "工作日";
    [SerializeField] private string remainingDaysOffHintFormat = "离下个阶段还有：{0:D}个休息日";

    public void ShowWeekday()
    {
        text.text = weekdayHint;
    }

    public void ShowRemainingDaysOff(int days)
    {
        text.text = String.Format(remainingDaysOffHintFormat, days);
    }
}