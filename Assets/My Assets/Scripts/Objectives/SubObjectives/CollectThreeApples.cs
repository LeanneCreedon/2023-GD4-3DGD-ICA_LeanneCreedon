using UnityEngine;

[CreateAssetMenu(fileName = "CollectApplesObjective", menuName = "Scriptable Objects/Sub-Objectives/CollectApples")]
public class CollectThreeApples : SO_Objective
{
    //[SerializeField] SO_ItemClass appleItem;
    void Start()
    {
        ObjectiveStep collectApplesStep = steps[0];
        collectApplesStep.targetAmount = 3; // collect three apples
    }

    public void UpdateProgressOnItemPickedUp()
    {
        UpdateStepProgress(0, 1); // 0 is the index of the step for collecting apples
    }
}
