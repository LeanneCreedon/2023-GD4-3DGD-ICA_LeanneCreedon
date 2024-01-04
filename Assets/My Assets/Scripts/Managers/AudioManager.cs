using UnityEngine;

/// <summary>
/// Manages audio settings.
/// </summary>

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField]
    public AudioSource source;

    [SerializeField]
    private AudioClip audioClip;

    private void Start()
    {
        Debug.Log("PLAYING MUSIC");
        source.PlayOneShot(audioClip);
    }
}
