using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPopupController : MonoBehaviour
{
    [SerializeField] private GButton buttonReturnToTitle;
    [SerializeField] private TextMeshProUGUI conclusion;
    [SerializeField] private string conclusionFormat = "{0}";
    [SerializeField] private string goodIntelligence = "";
    [SerializeField] private string goodVirtue = "";
    [SerializeField] private string goodHealth = "";
    [SerializeField] private PlayerAbilityData playerAbilityData;

    private void Start()
    {
        buttonReturnToTitle.OnClick = ReturnToTitle;
        ShowConclusion();
    }

    private void ShowConclusion()
    {
        List<Tuple<int, int>> stats = new()
        {
            new Tuple<int, int>(0, playerAbilityData.intelligence),
            new Tuple<int, int>(1, playerAbilityData.virtue),
            new Tuple<int, int>(2, playerAbilityData.body),
        };
        stats = stats.OrderByDescending(item => item.Item2).ToList();
        switch (stats[0].Item1)
        {
            case 0:
                conclusion.text = String.Format(conclusionFormat, goodIntelligence);
                break;
            case 1:
                conclusion.text = String.Format(conclusionFormat, goodVirtue);
                break;
            case 2:
                conclusion.text = String.Format(conclusionFormat, goodHealth);
                break;
        }
    }

    private void ReturnToTitle()
    {
        SoundManager.StopBackgroundMusic();
        SceneManager.LoadScene("Title");
    }
}