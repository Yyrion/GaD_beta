using UnityEngine;

public class CrystalShard : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Getting shard.");
        return true;
    }
}
