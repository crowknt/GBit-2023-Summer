using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePopupController : MonoBehaviour
{
    [SerializeField] private GButton buttonResume;
    [SerializeField] private GButton buttonReturnToTitle;

    private void Start()
    {
        buttonResume.OnClick = Resume;
        buttonReturnToTitle.OnClick = ReturnToTitle;
        SoundManager.PauseBackgroundMusic();
    }

    private void Resume()
    {
        SoundManager.ResumeBackgroundMusic();
        Destroy(gameObject);
    }

    private void ReturnToTitle()
    {
        SoundManager.StopBackgroundMusic();
        SceneManager.LoadScene("Title");
    }
}