#if UNITY_EDITOR
using UnityEditor;

/// <summary>
/// Generated using ChatGTP
/// 03/01/2024
/// 
/// Script for resetting the objective current amount variable to zero on exit play mode.
/// </summary>
[InitializeOnLoad]
public class ObjectiveResetEditor : UnityEditor.Editor
{
    static ObjectiveResetEditor()
    {
        EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
    }

    private static void OnPlayModeStateChanged(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.ExitingPlayMode)
        {
            ResetObjectiveValues();
        }
    }

    private static void ResetObjectiveValues()
    {
        // Find all ObjectiveSO assets in the project
        string[] assetPaths = AssetDatabase.FindAssets("t:SO_Objective");
        foreach (var assetPath in assetPaths)
        {
            string assetFullPath = AssetDatabase.GUIDToAssetPath(assetPath);
            SO_Objective objectiveSO = AssetDatabase.LoadAssetAtPath<SO_Objective>(assetFullPath);

            if (objectiveSO != null)
            {
                // Reset currentAmount to 0 for each step in the objective
                foreach (var step in objectiveSO.steps)
                {
                    step.currentAmount = 0;
                }

                // Reset isCompleted to false
                objectiveSO.isCompleted = false;

                // Save the changes to the asset
                EditorUtility.SetDirty(objectiveSO);
            }
        }

        // Save changes to all modified assets
        AssetDatabase.SaveAssets();
    }
}
#endif