using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] private float vel;
    
    private Rigidbody2D _rb2D;
   


    void Awake() => _rb2D = GetComponent<Rigidbody2D>();
    void FixedUpdate()
    {
        EnemyMove();
    }

    void EnemyMove()
    { 
        _rb2D.position = new Vector2(transform.position.x - (vel * Time.deltaTime), transform.position.y);
    }
}
