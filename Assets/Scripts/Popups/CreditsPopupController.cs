using UnityEngine;

public class CreditsPopupController : MonoBehaviour
{
    [SerializeField] private GButton buttonClose;

    private void Start()
    {
        buttonClose.OnClick = Close;
    }

    private void Close()
    {
        Destroy(gameObject);
    }
}