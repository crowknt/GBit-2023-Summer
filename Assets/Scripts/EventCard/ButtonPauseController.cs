using UnityEngine;

public class ButtonPauseController : MonoBehaviour
{
    [SerializeField] private Canvas canvas;

    [SerializeField] private GButton buttonPause;
    [SerializeField] private GameObject pausePopup;

    private void Start()
    {
        buttonPause.OnClick = Pause;
    }

    private void Pause()
    {
        Instantiate(pausePopup, canvas.transform);
    }
}