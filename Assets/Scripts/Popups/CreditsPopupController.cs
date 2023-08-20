using UnityEngine;
using UnityEngine.UI;

public class CreditsPopupController : MonoBehaviour
{
    [SerializeField] private Button buttonClose;

    private void Start()
    {
        buttonClose.onClick.AddListener(Close);
    }

    private void Close()
    {
        Destroy(gameObject);
    }
}