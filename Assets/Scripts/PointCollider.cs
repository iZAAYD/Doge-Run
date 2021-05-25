using UnityEngine;

public class PointCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.Points++;
    }
}