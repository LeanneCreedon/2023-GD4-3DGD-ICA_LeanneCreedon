using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

/// <summary>
/// Refereces Below
/// ***********************************************************************************
/// Niall's Repo 2023_GD4_Introduction:
/// https://github.com/nmcguinness/2023_GD4_Introduction
/// accessed - 27/12/2023
/// ---------------------
/// Stores Dictionary to hold game levels.
/// </summary>
[CreateAssetMenu(fileName = "Levels", menuName = "Scriptable Objects/Game/Levels")]
public class Levels : SerializedScriptableObject
{
    public Dictionary<string, List<Object>> Contents = new Dictionary<string, List<Object>>();
}