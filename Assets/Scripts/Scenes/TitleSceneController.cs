using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneController : MonoBehaviour
{
    [SerializeField] private GButton buttonNewGame;
    [SerializeField] private GButton buttonCredits;
    [SerializeField] private GButton buttonQuitGame;
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject creditsPopup;
    [SerializeField] private AudioClip backgroundMusic;
    [SerializeField] private PlayerAbilityData playerAbilityData;
    [SerializeField] private string firsetStage;

    private void Start()
    {
        buttonNewGame.OnClick = StartNewGame;
        buttonCredits.OnClick = ShowCredits;
        buttonQuitGame.OnClick = QuitGame;
        SoundManager.SwitchBackgroundMusic(backgroundMusic);
        
    }

    private void StartNewGame()
    {
        playerAbilityData.intelligence = 0;
        playerAbilityData.virtue = 0;
        playerAbilityData.body = 0;
        SceneManager.LoadScene(firsetStage);
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