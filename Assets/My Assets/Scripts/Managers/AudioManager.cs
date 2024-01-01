using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// Manages audio settings.
/// </summary>
public class AudioManager : Singleton<AudioManager>
{
    [SerializeField]
    private AudioMixer audioMixer;
}
