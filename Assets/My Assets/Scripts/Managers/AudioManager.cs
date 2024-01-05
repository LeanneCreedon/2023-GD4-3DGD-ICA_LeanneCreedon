using UnityEngine;

/// <summary>
/// Refereces Below
/// ***********************************************************************************
/// Niall's Repo 2023_GD4_Introduction:
/// https://github.com/nmcguinness/2023_GD4_Introduction
/// accessed - 17/12/2023
/// ---------------------
/// Manages Audio Settings
/// </summary>
public class AudioManager : Singleton<AudioManager>
{
    [SerializeField]
    public AudioSource source;

    [SerializeField]
    private AudioClip audioClip;

    private void Start()
    {
        source.PlayOneShot(audioClip);
    }
}
