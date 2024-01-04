using UnityEngine;

public class ObjectiveData : MonoBehaviour
{
    [SerializeField]
    private SO_Objective objectiveData;

    public SO_Objective GetObjective()
    {
        return objectiveData;
    }
}

