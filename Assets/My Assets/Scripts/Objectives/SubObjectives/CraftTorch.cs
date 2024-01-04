using UnityEngine;

[CreateAssetMenu(fileName = "CraftTorchObjective", menuName = "Scriptable Objects/Sub-Objectives/CraftTorch")]
public class CraftTorch : SO_Objective
{
    void Start()
    {
        ObjectiveStep collectLeaf = steps[0];
        collectLeaf.targetAmount = 1; // have leaf

        ObjectiveStep collectStick = steps[1];
        collectStick.targetAmount = 1; // have stick

        ObjectiveStep torch = steps[1];
        torch.targetAmount = 1; // craft torch
    }

    public void UpdateProgressOnCraftItem()
    {
        UpdateStepProgress(0, 1); // 0 is the index of the step for collecting apples
    }
}
