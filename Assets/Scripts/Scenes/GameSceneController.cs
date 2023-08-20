using UnityEngine;
<<<<<<< HEAD
using UnityEngine.UI;
=======
>>>>>>> 6162d725ffc1cd009b27901455e6f3e86d791796

public class GameSceneController : MonoBehaviour
{
    [SerializeField] private Canvas canvas;

<<<<<<< HEAD
    [SerializeField] private Button buttonPause;
=======
    [SerializeField] private GButton buttonPause;
>>>>>>> 6162d725ffc1cd009b27901455e6f3e86d791796
    [SerializeField] private GameObject pausePopup;

    private void Start()
    {
<<<<<<< HEAD
        buttonPause.onClick.AddListener(Pause);
=======
        buttonPause.OnClick = Pause;
>>>>>>> 6162d725ffc1cd009b27901455e6f3e86d791796
    }

    private void Pause()
    {
        Instantiate(pausePopup, canvas.transform);
    }
}