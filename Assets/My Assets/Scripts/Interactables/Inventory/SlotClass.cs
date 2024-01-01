using UnityEngine;

[System.Serializable]
public class SlotClass : MonoBehaviour
{
    [SerializeField] private SO_ItemClass item;

    public SlotClass()
    {
        item = null;
    }

    public SlotClass(SO_ItemClass _item)
    {
        item = _item;
    }

    public SO_ItemClass GetItem() { return item; }
}
