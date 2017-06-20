using UnityEngine;


// ReSharper disable once CheckNamespace
public class RandomRotator : MonoBehaviour
{
	public float Tumble;

	void Start()
	{
		var body = GetComponent<Rigidbody>();
		body.angularVelocity = Random.insideUnitSphere * Tumble;
	}
}
