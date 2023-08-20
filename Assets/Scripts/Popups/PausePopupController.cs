using UnityEngine;
using UnityEngine.SceneManagement;
<<<<<<< HEAD
using UnityEngine.UI;

public class PausePopupController : MonoBehaviour
{
    [SerializeField] private Button buttonResume;
    [SerializeField] private Button buttonSettings;
    [SerializeField] private Button buttonReturnToTitle;

    private void Start()
    {
        buttonResume.onClick.AddListener(Resume);
        buttonSettings.onClick.AddListener(OpenSettings);
        buttonReturnToTitle.onClick.AddListener(ReturnToTitle);
=======

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
>>>>>>> 6162d725ffc1cd009b27901455e6f3e86d791796
    }

    private void Resume()
    {
<<<<<<< HEAD
=======
        SoundManager.ResumeBackgroundMusic();
>>>>>>> 6162d725ffc1cd009b27901455e6f3e86d791796
        Destroy(gameObject);
    }

    private void OpenSettings()
    {
        Debug.Log("TODO: Settings");
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