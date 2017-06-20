using UnityEngine;

// ReSharper disable once CheckNamespace
public class DestroyByTime : MonoBehaviour
{
	public float Lifetime;
	
	void Start ()
	{
		Destroy(gameObject, Lifetime);
	}
}
