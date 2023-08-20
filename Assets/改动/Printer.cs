using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Printer : MonoBehaviour
{
    [Header("打字速度")]
    public float Speed = 15;

    [TextArea(3,4),Tooltip("事件内容")] public string tx;
    
    public TextMeshProUGUI text;

    void Start( )
    {
        //Run(tx, text);
    }
    public void Run(string textToType, TextMeshProUGUI textLabel)
    {
        StartCoroutine(TypeText(textToType, textLabel));
    }
    IEnumerator TypeText(string textToType, TextMeshProUGUI textLabel)
    {
        float t = 0;//经过的时间
        int charIndex = 0;//字符串索引值
        while (charIndex < textToType.Length)
        {
            t += Time.deltaTime * Speed;//简单计时器赋值给t
            charIndex = Mathf.FloorToInt(t);//把t转为int类型赋值给charIndex
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);
            textLabel.text = textToType.Substring(0, charIndex);

            yield return null;
        }
        textLabel.text = textToType;
    }
}
