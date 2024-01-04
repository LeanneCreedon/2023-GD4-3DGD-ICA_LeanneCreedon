using UnityEngine;

public class _CraftTorchData : MonoBehaviour
{
    [SerializeField]
    private SO_Objective objectiveData;

    public SO_Objective GetObjective()
    {
        return objectiveData;
    }
}
