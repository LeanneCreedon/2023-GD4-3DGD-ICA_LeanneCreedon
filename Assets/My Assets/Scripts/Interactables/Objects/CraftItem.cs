using UnityEngine;

public class CraftItem : MonoBehaviour
{
    [SerializeField] private Item thisItem;
    [SerializeField] private DialogueInteract dialogueCraft;
    [SerializeField] private ItemDataGameEvent OnCraftItem;
    public bool CraftResponse()
    {
        if (thisItem != null)
        {
            OnCraftItem.Raise(thisItem.GetItem());
            AudioSource.PlayClipAtPoint(thisItem.GetItem().PickupClip, this.transform.position);
            return true;
        }
        return false;
    }
}
