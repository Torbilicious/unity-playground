using UnityEngine;

// ReSharper disable once CheckNamespace
public class DestroyByContact : MonoBehaviour
{
    public GameObject Explosion;
    public GameObject PlayerExplosion;
    private GameController gameController;
    public int ScoreValue;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }

        if (gameController == null)
        {
            Debug.LogError("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter(Component other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }

        Instantiate(Explosion, transform.position, transform.rotation);

        if (other.tag == "Player")
        {
            Instantiate(PlayerExplosion, other.transform.position, other.transform.rotation);
            
            gameController.EndGame();
        }

        gameController.IncreaseScoreBy(ScoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}