using UnityEngine;

// ReSharper disable once CheckNamespace
public class Mover : MonoBehaviour
{
    public float Speed;
    
    void Start()
    {
        var bolt = GetComponent<Rigidbody>();
        bolt.velocity = transform.forward * Speed;
    }
}