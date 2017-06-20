using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

// ReSharper disable once CheckNamespace
public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 SpawnValues;
    public int HazardAmount;
    public float SpawnWait;
    public float StartWait;
    public float WaveWait;

    public GUIText ScoreText;
    public GUIText RestartText;
    public GUIText GameOverText;
    private int Score;

    private bool GameOver;
    private bool Restart;

    void Start()
    {
        Score = 0;
        UpdateScore();

        RestartText.text = "";
        GameOverText.text = "";
        
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        if (!Restart) return;
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
    private IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(StartWait);

        for (;;)
        {
            for (int i = 0; i < HazardAmount; i++)
            {
                Vector3 SpawnPosition = new Vector3(Random.Range(-SpawnValues.x, SpawnValues.x), SpawnValues.y, SpawnValues.z);
                Quaternion SpawnRotation = Quaternion.identity;
                Instantiate(hazard, SpawnPosition, SpawnRotation);
                
                yield return new WaitForSeconds(SpawnWait);
            }
            
            yield return new WaitForSeconds(WaveWait);

            if (GameOver)
            {
                RestartText.text = "Press 'R' for Restart!";
                Restart = true;
                break;
            }
        }
    }

    public void IncreaseScoreBy(int Points)
    {
        Score += Points;
        UpdateScore();
    }

    private void UpdateScore()
    {
        ScoreText.text = "Score: " + Score;
    }

    public void EndGame()
    {
        GameOverText.text = "Game Over!";
        GameOver = true;
    }
}