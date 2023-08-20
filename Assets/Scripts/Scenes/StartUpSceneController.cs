using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUpSceneController : MonoBehaviour
{
    private bool loadingTitleScene;

    private void Update()
    {
        if (loadingTitleScene) return;
        SceneManager.LoadScene("Title");
        loadingTitleScene = true;
    }
}