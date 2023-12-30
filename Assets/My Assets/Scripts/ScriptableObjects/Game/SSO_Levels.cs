using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

[CreateAssetMenu(fileName = "Levels", menuName = "Scriptable Objects/Game/Levels")]
public class Levels : SerializedScriptableObject
{
    public Dictionary<string, List<Object>> Contents = new Dictionary<string, List<Object>>();
}