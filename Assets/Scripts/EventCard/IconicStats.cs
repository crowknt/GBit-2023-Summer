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
    [SerializeField] private PlayerAbilityData abilityData;

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

    private void Awake()
    {
        EventCenter.Instance.AddListener("SliderFillChange",SliderFillChange);
        EventCenter.Instance.AddListener("IntelligenceHighlight",IntelligenceHighlight);
        EventCenter.Instance.AddListener("VirtueHighlight",VirtueHighlight);
        EventCenter.Instance.AddListener("BodyHighlight",BodyHighlight);
        EventCenter.Instance.AddListener("ClearHighlights",ClearHighlights);
    }

    private void Start()
    {
        SliderFillChange();
    }

    private void SliderFillChange()
    {
        Intelligence = (float)abilityData.intelligence;
        Virtue = (float)abilityData.virtue;
        Health = (float)abilityData.body;
    }

    private void IntelligenceHighlight()
    {
        IntelligenceHighlighted = true;
    }

    private void VirtueHighlight()
    {
        VirtueHighlighted = true;
    }

    private void BodyHighlight()
    {
        HealthHighlighted = true;
    }

    private void OnDestroy()
    {
        EventCenter.Instance.RemoveEventListener("SliderFillChange",SliderFillChange);
        EventCenter.Instance.RemoveEventListener("IntelligenceHighlight",IntelligenceHighlight);
        EventCenter.Instance.RemoveEventListener("VirtueHighlight",VirtueHighlight);
        EventCenter.Instance.RemoveEventListener("BodyHighlight",BodyHighlight);
        EventCenter.Instance.RemoveEventListener("ClearHighlights",ClearHighlights);
    }
}