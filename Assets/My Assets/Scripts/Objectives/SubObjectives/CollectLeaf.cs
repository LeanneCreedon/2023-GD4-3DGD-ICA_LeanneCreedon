using UnityEngine;

[CreateAssetMenu(fileName = "CollectLeafObjective", menuName = "Scriptable Objects/Sub-Objectives/CollectLeaf")]
public class CollectLeaf : SO_Objective
{
    void Start()
    {
        ObjectiveStep collectLeafStep = steps[0];
        collectLeafStep.targetAmount = 1; // collect three apples
    }

    public void UpdateProgressOnItemPickedUp()
    {
        UpdateStepProgress(0, 1); // 0 is the index of the step for collecting apples
    }
}
