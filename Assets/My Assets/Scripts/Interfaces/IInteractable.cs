/// <summary>
/// Refereces Below
/// ***********************************************************************************
/// Tutorial Followed:
/// Unity Interaction System | How To Interact With Any Game Object In Unity, Dan Pos -
/// https://www.youtube.com/watch?v=THmW4YolDok&t=861s
/// accessed - 19/12/2023
/// ---------------------
/// Interface used for all interactions between the player and other game objects that are interactable.
/// </summary>
public interface IInteractable
{
    public string InteractionPrompt { get; }
    public bool Interact(Interactor interactor);
}
