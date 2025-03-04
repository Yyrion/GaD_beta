using UnityEngine;

public interface IInteractable
{
    public string InteractionPrompt { get; }
    public string InteractionMessage { get; }
    public bool Interact(Interactor interactor);
}
