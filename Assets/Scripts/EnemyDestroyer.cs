using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        { 
            Destroy(other.gameObject);
        }
    }
}
