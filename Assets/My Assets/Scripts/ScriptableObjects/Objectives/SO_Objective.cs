using UnityEngine;

[CreateAssetMenu(fileName = "NewObjective", menuName = "Scriptable Objects/Objectives/Objective")]
public class SO_Objective : ScriptableObject
{
    public string objectiveName;
    public string description;
    public bool isCompleted;

    public void MarkAsCompleted()
    {
        isCompleted = true;
    }

    public SO_Objective GetObjective() { return this; }
}
