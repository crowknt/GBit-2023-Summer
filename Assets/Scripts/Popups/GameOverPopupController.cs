using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
<<<<<<< HEAD
using UnityEngine.UI;

public class GameOverPopupController : MonoBehaviour
{
    [SerializeField] private Button buttonReturnToTitle;
=======

public class GameOverPopupController : MonoBehaviour
{
    [SerializeField] private GButton buttonReturnToTitle;
>>>>>>> 6162d725ffc1cd009b27901455e6f3e86d791796
    [SerializeField] private TextMeshProUGUI conclusion;
    [SerializeField] private string conclusionFormat = "{0}";
    [SerializeField] private string goodIntelligence = "";
    [SerializeField] private string goodVirtue = "";
    [SerializeField] private string goodHealth = "";
    [SerializeField] private PlayerAbilityData playerAbilityData;

    private void Start()
    {
<<<<<<< HEAD
        buttonReturnToTitle.onClick.AddListener(ReturnToTitle);
=======
        buttonReturnToTitle.OnClick = ReturnToTitle;
>>>>>>> 6162d725ffc1cd009b27901455e6f3e86d791796
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
<<<<<<< HEAD
=======
        SoundManager.StopBackgroundMusic();
>>>>>>> 6162d725ffc1cd009b27901455e6f3e86d791796
        SceneManager.LoadScene("Title");
    }
}