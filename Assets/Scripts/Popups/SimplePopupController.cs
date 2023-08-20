using UnityEngine;

public class SimplePopupController : MonoBehaviour
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