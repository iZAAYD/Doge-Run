using UnityEngine;

public class CollisionDeath : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Enemy")) return;
        AudioManager.Instance.source.PlayOneShot(AudioManager.Instance.catDeath);
        gameManager.EndGame();
        Destroy(gameObject);
    }
}
