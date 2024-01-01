using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private SO_ItemClass itemData;

    public SO_ItemClass GetItem()
    {
        return itemData;
    }
}

