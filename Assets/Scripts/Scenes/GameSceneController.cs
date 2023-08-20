using UnityEngine;
using UnityEngine.UI;

public class GameSceneController : MonoBehaviour
{
    [SerializeField] private Canvas canvas;

    [SerializeField] private Button buttonPause;
    [SerializeField] private GameObject pausePopup;

    private void Start()
    {
        buttonPause.onClick.AddListener(Pause);
    }

    private void Pause()
    {
        Instantiate(pausePopup, canvas.transform);
    }
}