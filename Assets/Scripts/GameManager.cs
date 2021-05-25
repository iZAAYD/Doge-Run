using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int Points = 0;
    public static int HighScore;
    
    [SerializeField] private float gameVelocityIncrement;
    [SerializeField] private float incrementInterval;
    [SerializeField] private EnemyGenerator enemyGenerator;

    public GameState CurrentGameState { get; private set; }

     public enum GameState
    {
        Idle,
        Playing,
        Ended
    }
    
    private void Start()
    {
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
        CurrentGameState = GameState.Idle;
    }

    private void Update()
    {
        if (CurrentGameState == GameState.Idle && Input.GetKeyDown(KeyCode.Space))
        {
            CurrentGameState = GameState.Playing;
            StartCoroutine(IncreaseGameSpeed(incrementInterval));
            StartCoroutine(enemyGenerator.SpawnEnemy());
        }
        if (Points > HighScore)
        {
            HighScore = Points;
        }
    }

    public void EndGame()
    {
        Time.timeScale = 1;
        CurrentGameState = GameState.Ended;
        PlayerPrefs.SetInt("HighScore", HighScore);
        Points = 0;
    }
    
    IEnumerator IncreaseGameSpeed(float timer)
    {
        while (CurrentGameState == GameState.Playing)
        {
            Time.timeScale += gameVelocityIncrement * Time.unscaledDeltaTime;
            yield return new WaitForSeconds(timer);
        }
    }
}