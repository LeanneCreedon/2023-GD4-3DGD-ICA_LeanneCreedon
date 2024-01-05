using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Refereces Below
/// ***********************************************************************************
/// Niall's Repo 2023_GD4_Introduction:
/// https://github.com/nmcguinness/2023_GD4_Introduction
/// accessed - 28/12/2023
/// ---------------------
/// Event Listener to listen for all base game events.
/// </summary>
public class BaseGameEventListener<T> : MonoBehaviour
{
    [SerializeField]
    private string description;

    [SerializeField]
    [Tooltip("Specify the game event (scriptable object) which will raise the event")]
    private BaseGameEvent<T> Event;

    [SerializeField]
    private UnityEvent<T> Response;

    private void OnEnable() => Event.RegisterListener(this);

    private void OnDisable() => Event.UnregisterListener(this);

    public virtual void OnEventRaised(T data) => Response?.Invoke(data);
}
