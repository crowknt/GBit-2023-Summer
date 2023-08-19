using System;
using UnityEngine;
using UnityEngine.UI;

public class IconicStats : MonoBehaviour
{
    [SerializeField] private Slider sliderIntelligence;
    [SerializeField] private Slider sliderVirtue;
    [SerializeField] private Slider sliderHealth;
    [SerializeField] private Image intelligenceHighlight;
    [SerializeField] private Image virtueHighlight;
    [SerializeField] private Image healthHighlight;

    public float Intelligence
    {
        get => sliderIntelligence.value;
        set => sliderIntelligence.value = value;
    }

    public bool IntelligenceHighlighted
    {
        get => intelligenceHighlight.enabled;
        set => intelligenceHighlight.enabled = value;
    }

    public float Virtue
    {
        get => sliderVirtue.value;
        set => sliderVirtue.value = value;
    }


    public bool VirtueHighlighted
    {
        get => virtueHighlight.enabled;
        set => virtueHighlight.enabled = value;
    }

    public float Health
    {
        get => sliderHealth.value;
        set => sliderHealth.value = value;
    }

    public bool HealthHighlighted
    {
        get => healthHighlight.enabled;
        set => healthHighlight.enabled = value;
    }

    public void ClearHighlights()
    {
        IntelligenceHighlighted = false;
        VirtueHighlighted = false;
        HealthHighlighted = false;
    }
}