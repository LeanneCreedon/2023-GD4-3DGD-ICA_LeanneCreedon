using UnityEngine;

/// <summary>
/// Refereces Below
/// ***********************************************************************************
/// Gotten from Niall's Repo 2023_GD4_Introduction:
/// https://github.com/nmcguinness/2023_GD4_Introduction
/// accessed - 29/12/2023
/// ---------------------
/// Script to handle Item Data Scriptable Object
/// </summary>
public class ItemDataBehaviour : MonoBehaviour
{
    [SerializeField]
    private SO_ItemClass itemData;

    public SO_ItemClass ItemData { get => itemData; protected set => itemData = value; }
}