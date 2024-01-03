using System.Collections;
using UnityEngine;

public class OnDestroyBehaviour : MonoBehaviour
{
    public void OnRemoveItem(GameObject objectToDestroy)
    {
        StartCoroutine(RemoveItem(objectToDestroy));
    }
    IEnumerator RemoveItem(GameObject objectToDestroy)
    {
        yield return new WaitForSeconds(3);
        Destroy(objectToDestroy);
    }
}
