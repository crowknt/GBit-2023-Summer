using UnityEngine;
using UnityEngine.SceneManagement;
<<<<<<< HEAD
using UnityEngine.UI;

public class TitleSceneController : MonoBehaviour
{
    [SerializeField] private Button buttonNewGame;
    [SerializeField] private Button buttonCredits;
    [SerializeField] private Button buttonQuitGame;
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject creditsPopup;

    private void Start()
    {
        buttonNewGame.onClick.AddListener(StartNewGame);
        buttonCredits.onClick.AddListener(ShowCredits);
        buttonQuitGame.onClick.AddListener(QuitGame);
=======

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
>>>>>>> 6162d725ffc1cd009b27901455e6f3e86d791796
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