using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePopupController : MonoBehaviour
{
    [SerializeField] private GButton buttonResume;
    [SerializeField] private GButton buttonSettings;
    [SerializeField] private GButton buttonReturnToTitle;

    private void Start()
    {
        buttonResume.OnClick = Resume;
        buttonSettings.OnClick = OpenSettings;
        buttonReturnToTitle.OnClick = ReturnToTitle;
        SoundManager.PauseBackgroundMusic();
    }

    private void Resume()
    {
        SoundManager.ResumeBackgroundMusic();
        Destroy(gameObject);
    }

    private void OpenSettings()
    {
        Debug.Log("TODO: Settings");
    }

    private void ReturnToTitle()
    {
        SoundManager.StopBackgroundMusic();
        SceneManager.LoadScene("Title");
    }
}