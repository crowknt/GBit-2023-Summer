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
    [SerializeField] private TextualStats textualStats;
    [SerializeField] private string loseFormat = "{0}";
    
    private bool _isSpecial = false;
    private string _specialText;
    private bool _isLose = false;
    private void Start()
    {
        buttonReturnToTitle.OnClick = ReturnToTitle;
        ShowConclusion();
    }

    public void Update()
    {
        textualStats.ChangeText(playerAbilityData.intelligence,playerAbilityData.virtue,playerAbilityData.body);
    }

    public void ShowConclusion()
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

        if (_isSpecial)
        {
            conclusion.text = _specialText;
        }

        if (_isLose)
        {
            LoseEndText();
        }
    }

    public void SpecialEndTextChange(string specialText)
    {
        _specialText = specialText;
        _isSpecial = true;
    }

    public void LosePop()
    {
        _isLose = true;
    }

    private void LoseEndText()
    {
        if (playerAbilityData.intelligence == 0)
        {
            conclusion.text = String.Format(loseFormat, goodIntelligence);
        }
        if (playerAbilityData.virtue == 0)
        {
            conclusion.text = String.Format(loseFormat, goodVirtue);
        }

        if (playerAbilityData.body == 0)
        {
            conclusion.text = String.Format(loseFormat, goodHealth);
        }

        _isLose = false;
    }

    private void ReturnToTitle()
    {
        
        SoundManager.StopBackgroundMusic();
        SceneManager.LoadScene("Title");
    }
}