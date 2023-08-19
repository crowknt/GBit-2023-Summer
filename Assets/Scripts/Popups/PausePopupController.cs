using UnityEngine;
using UnityEngine.SceneManagement;
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
    }

    private void Resume()
    {
        Destroy(gameObject);
    }

    private void OpenSettings()
    {
        Debug.Log("TODO: Settings");
    }

    private void ReturnToTitle()
    {
        SceneManager.LoadScene("Title");
    }
}