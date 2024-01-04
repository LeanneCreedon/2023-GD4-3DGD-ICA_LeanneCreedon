using UnityEngine;

public class _CollectThreeApplesData : MonoBehaviour
{
    [SerializeField]
    private SO_Objective objectiveData;

    public SO_Objective GetObjective()
    {
        return objectiveData;
    }
}