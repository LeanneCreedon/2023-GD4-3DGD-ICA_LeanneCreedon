using UnityEngine;

[CreateAssetMenu(fileName = "CreateFireTorchObjective", menuName = "Scriptable Objects/Sub-Objectives/LightTorch")]
public class CreateFireTorch : SO_Objective
{
    void Start()
    {
        ObjectiveStep collectedTorch = steps[0];
        collectedTorch.targetAmount = 1;
    }

    public void UpdateProgressOnCraftItem()
    {
        UpdateStepProgress(0, 1); // 0 is the index of the step for collecting apples
    }
}
