using UnityEngine;

/// <summary>
/// Refereces Below
/// ***********************************************************************************
/// ChatGPT was used to help develop this implementation of an objective system.
/// ChatGPT Open AI - https://chat.openai.com/auth/login
/// accessed - 02/12/2023
/// ---------------------
/// Manager Script to manage the objectives of the game.
/// </summary>
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
