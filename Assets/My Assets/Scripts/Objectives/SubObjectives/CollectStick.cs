using UnityEngine;

[CreateAssetMenu(fileName = "CollectStickObjective", menuName = "Scriptable Objects/Sub-Objectives/CollectStick")]
public class CollectStick : SO_Objective
{
    void Start()
    {
        ObjectiveStep collectStickStep = steps[0];
        collectStickStep.targetAmount = 1; // collect 1 stick
    }

    public void UpdateProgressOnItemPickedUp()
    {
        UpdateStepProgress(0, 1); // 0 is the index of the step for collecting apples
    }
}
