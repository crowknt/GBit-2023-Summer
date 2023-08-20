using UnityEngine;

public class GButton : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Button button;
    [SerializeField] private AudioClip clickSound;

    public delegate void OnClickCallback();

    public OnClickCallback OnClick = null;

    private void Start()
    {
        button.onClick.AddListener(OnClickImpl);
    }

    private void OnClickImpl()
    {
        SoundManager.PlaySoundEffect(clickSound);
        if (OnClick is not null)
            OnClick();
    }
}