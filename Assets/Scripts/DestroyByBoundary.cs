using UnityEngine;

// ReSharper disable once CheckNamespace
public class DestroyByBoundary : MonoBehaviour {

    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
