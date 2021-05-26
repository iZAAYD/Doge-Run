using UnityEngine;
public class PointCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        AudioManager.Instance.source.PlayOneShot(AudioManager.Instance.pointsClip);
        GameManager.Points++;
    }
}