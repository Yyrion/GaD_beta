using UnityEngine;

public class CrystalShardInteraction : MonoBehaviour, IInteractable
{
    public string InteractionPrompt => throw new System.NotImplementedException();

    public string InteractionMessage => throw new System.NotImplementedException();

    public bool Interact(Interactor interactor)
    {
        Debug.Log("CrystalShard");
        return true;
    }
}
