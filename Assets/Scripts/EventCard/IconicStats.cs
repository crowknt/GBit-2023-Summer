using UnityEngine;
using UnityEngine.UI;

public class IconicStats : MonoBehaviour
{
    [SerializeField] private Slider sliderIntelligence;
    [SerializeField] private Slider sliderVirtue;
    [SerializeField] private Slider sliderHealth;

    public float Intelligence
    {
        get => sliderIntelligence.value;
        set => sliderIntelligence.value = value;
    }

    public float Virtue
    {
        get => sliderVirtue.value;
        set => sliderVirtue.value = value;
    }

    public float Health
    {
        get => sliderHealth.value;
        set => sliderHealth.value = value;
    }
}