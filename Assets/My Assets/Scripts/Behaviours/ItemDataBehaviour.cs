using UnityEngine;

public class ItemDataBehaviour : MonoBehaviour
{
    [SerializeField]
    private SO_ItemClass itemData;

    public SO_ItemClass ItemData { get => itemData; protected set => itemData = value; }
}