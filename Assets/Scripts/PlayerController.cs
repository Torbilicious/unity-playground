using UnityEngine;


// ReSharper disable once CheckNamespace
[System.Serializable]
public class Boundary
{
    public float XMin = -7.0f;
    public float XMax = 7.0f;
    public float ZMin = -4.0f;
    public float ZMax = 8.0f;
}

// ReSharper disable once CheckNamespace
public class PlayerController : MonoBehaviour
{
    //Ship related Variables
    public float Speed = 10.0f;
    public float Tilt = 3.0f;
    public Boundary Boundary;

    
    //Lasershot related Variables
    public GameObject Shot;
    public Transform ShotSpawn;
    public float FireRate = 0.25f;
    private float NextFire;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > NextFire)
        {
            NextFire = Time.time + FireRate;
            Instantiate(Shot, ShotSpawn.position, ShotSpawn.rotation);

            GetComponent<AudioSource>().Play();
        }
    }
    
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        var ship = GetComponent<Rigidbody>();
        
        
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        ship.velocity = movement * Speed;


        float newX = Mathf.Clamp(ship.position.x, Boundary.XMin, Boundary.XMax);
        float newZ = Mathf.Clamp(ship.position.z, Boundary.ZMin, Boundary.ZMax);
        ship.position = new Vector3(newX, 0.0f, newZ);
        ship.rotation = Quaternion.Euler(0f, 0.0f, ship.velocity.x * -Tilt);
    }
}