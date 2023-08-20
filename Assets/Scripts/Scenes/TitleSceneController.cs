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

    private void Start()
    {
        buttonNewGame.OnClick = StartNewGame;
        buttonCredits.OnClick = ShowCredits;
        buttonQuitGame.OnClick = QuitGame;
        SoundManager.SwitchBackgroundMusic(backgroundMusic);
    }

    private void StartNewGame()
    {
        SceneManager.LoadScene("Game_flf");
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