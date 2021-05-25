using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private GameObject enemy, enemy2;
    [SerializeField] private float timer;
    [SerializeField] private GameManager gameManager;


    public IEnumerator SpawnEnemy()
    {
        while (gameManager.CurrentGameState == GameManager.GameState.Playing)
        {
            var chance = Random.value;
            if (chance > 0.5)
            {
                Instantiate(enemy2, transform, false);
            }
            else
            {
                Instantiate(enemy, transform, false);
            }

            yield return new WaitForSeconds(timer);
        }
    }
}