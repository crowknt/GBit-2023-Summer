using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleSceneController : MonoBehaviour
{
    [SerializeField] private Button buttonNewGame;
    [SerializeField] private Button buttonCredits;
    [SerializeField] private Button buttonQuitGame;

    private void Start()
    {
        buttonNewGame.onClick.AddListener(StartNewGame);
        buttonCredits.onClick.AddListener(ShowCredits);
        buttonQuitGame.onClick.AddListener(QuitGame);
    }

    private void StartNewGame()
    {
        SceneManager.LoadScene("Game_flf");
    }

    private void ShowCredits()
    {
        Debug.Log("TODO: Credits");
    }

    private void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}