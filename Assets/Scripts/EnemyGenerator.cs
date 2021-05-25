using System.Collections;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
   [SerializeField] private GameObject enemy;
   [SerializeField] private float timer;

   private void Start()
   {
      StartCoroutine(SpawnEnemy());
   }

   IEnumerator SpawnEnemy()
   {
      while (true)
      {
         Instantiate(enemy, transform, false);
         yield return new WaitForSeconds(timer);
      }
   }
}
