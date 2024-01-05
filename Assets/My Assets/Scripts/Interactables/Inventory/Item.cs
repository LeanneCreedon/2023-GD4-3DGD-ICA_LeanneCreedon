using UnityEngine;

/// <summary>
/// ---------------------------
/// Script for getting the data from the scriptable object. Allowes the script to be attached to the object
/// as the scriptable object class itself cannot be attached to the object as it must derive from 
/// Monobehaviour or be an interface.
/// ---------------------------
/// </summary>
public class Item : MonoBehaviour
{
    [SerializeField]
    private SO_ItemClass itemData;

    public SO_ItemClass GetItem()
    {
        return itemData;
    }
}

