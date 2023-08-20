using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource sfx;
    [SerializeField] private AudioSource music;

    private static SoundManager _instance;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        _instance = this;
    }

    public static void PlaySoundEffect(AudioClip clip)
    {
        if (_instance is null) return;
        _instance.sfx.PlayOneShot(clip);
    }

    public static void SwitchBackgroundMusic(AudioClip clip)
    {
        if (_instance is null) return;
        _instance.music.clip = clip;
        _instance.music.Play();
    }

    public static void PauseBackgroundMusic()
    {
        if (_instance is null) return;
        _instance.music.Pause();
    }

    public static void ResumeBackgroundMusic()
    {
        if (_instance is null) return;
        _instance.music.Play();
    }

    public static void StopBackgroundMusic()
    {
        if (_instance is null) return;
        _instance.music.Stop();
        _instance.music.clip = null;
    }
}