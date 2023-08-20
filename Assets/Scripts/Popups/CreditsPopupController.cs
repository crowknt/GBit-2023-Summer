using UnityEngine;
<<<<<<< HEAD
using UnityEngine.UI;

public class CreditsPopupController : MonoBehaviour
{
    [SerializeField] private Button buttonClose;

    private void Start()
    {
        buttonClose.onClick.AddListener(Close);
=======

public class CreditsPopupController : MonoBehaviour
{
    [SerializeField] private GButton buttonClose;

    private void Start()
    {
        buttonClose.OnClick = Close;
>>>>>>> 6162d725ffc1cd009b27901455e6f3e86d791796
    }

    private void Close()
    {
        Destroy(gameObject);
    }
}