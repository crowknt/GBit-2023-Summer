using System;
using TMPro;
using UnityEngine;

public class TextualStats : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI intelligenceText;
    [SerializeField] private TextMeshProUGUI virtueText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private string format = "{0:F0}";

    private void Start()
    {
        Intelligence = 0;
        Virtue = 0;
        Health = 0;
    }

    private float intelligence;

    public float Intelligence
    {
        get => intelligence;
        set
        {
            intelligence = value;
            intelligenceText.text = String.Format(format, value);
        }
    }

    private float virtue;

    public float Virtue
    {
        get => virtue;
        set
        {
            virtue = value;
            virtueText.text = String.Format(format, value);
        }
    }

    private float health;

    public float Health
    {
        get => health;
        set
        {
            health = value;
            healthText.text = String.Format(format, value);
        }
    }

    public void ChangeText(int newIntelligence, int newVirtue, int newBody)
    {
        Intelligence = newIntelligence;
        Virtue = newVirtue;
        Health = newBody;
    }
}