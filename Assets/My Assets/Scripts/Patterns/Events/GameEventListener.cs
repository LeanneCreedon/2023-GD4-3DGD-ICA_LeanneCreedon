using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Refereces Below
/// ***********************************************************************************
/// Niall's Repo 2023_GD4_Introduction:
/// https://github.com/nmcguinness/2023_GD4_Introduction
/// accessed - 28/12/2023
/// ---------------------
/// Game Event Listener to listen for game events.
/// </summary>
public class GameEventListener : MonoBehaviour
{
    [SerializeField]
    private string description;

    [SerializeField]
    [Tooltip("Specify the game event (scriptable object) which will raise the event")]
    private SGO_GameEvent Event;

    [SerializeField]
    private UnityEvent Response;

    private void OnEnable() => Event.RegisterListener(this);

    private void OnDisable() => Event.UnregisterListener(this);

    public virtual void OnEventRaised() => Response?.Invoke();
}
