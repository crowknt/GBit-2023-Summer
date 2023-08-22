using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class TitleSceneController : MonoBehaviour
{
    [SerializeField] private GButton buttonNewGame;
    [SerializeField] private GButton buttonHelp;
    [SerializeField] private GButton buttonCredits;
    [SerializeField] private GButton buttonQuitGame;
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject creditsPopup;
    [SerializeField] private GameObject helpPopup;
    [SerializeField] private AudioClip backgroundMusicTitle;
    [SerializeField] private AudioClip backgroundMusicGame;
    [SerializeField] private PlayerAbilityData playerAbilityData;
    [SerializeField] private string firsetStage;

    private void Start()
    {
        buttonNewGame.OnClick = StartNewGame;
        buttonHelp.OnClick = ShowHelp;
        buttonCredits.OnClick = ShowCredits;
        buttonQuitGame.OnClick = QuitGame;
        SoundManager.SwitchBackgroundMusic(backgroundMusicTitle);
        
    }

    private void StartNewGame()
    {
        playerAbilityData.intelligence = 0;
        playerAbilityData.virtue = 0;
        playerAbilityData.body = 0;
        SceneManager.LoadScene(firsetStage);
        SoundManager.SwitchBackgroundMusic(backgroundMusicGame);
    }

    private void ShowHelp()
    {
        Instantiate(helpPopup, canvas.transform);
    }

    private void ShowCredits()
    {
        Instantiate(creditsPopup, canvas.transform);
    }

    private void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}