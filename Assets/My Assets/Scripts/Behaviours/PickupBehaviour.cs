using UnityEngine;

public class PickupBehaviour : MonoBehaviour
{
    [SerializeField]
    private string targetTag = "QuestObjectPickup";

    [SerializeField]
    private ItemDataGameEvent OnPickup;

    private void Awake()
    {
        targetTag.Trim();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals(targetTag))
        {
            //get item data
            var behaviour = other.gameObject.GetComponent<ItemDataBehaviour>();

            if (behaviour != null)
            {
                var itemData = behaviour.ItemData;
                //raise the event
                //OnPickup?.Raise(itemData);
                //play the sound
                AudioSource.PlayClipAtPoint(itemData.PickupClip,
                    other.gameObject.transform.position);

                Destroy(other.gameObject);//, itemData.PickupClip.length);
            }
        }
    }
}