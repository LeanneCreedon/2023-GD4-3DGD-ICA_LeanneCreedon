using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private ItemClass itemData;

    public ItemClass GetItem()
    {
        return itemData;
    }
}

