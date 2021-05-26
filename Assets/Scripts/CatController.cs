using UnityEngine;

public class CatController : MonoBehaviour
{
    [SerializeField] float vel;
    [SerializeField] GameManager gameManager;

    private Rigidbody2D _rb;
    private Animator _anim;
    private bool _isJumping, _jumped;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }


    private void Update()
    {
        if (gameManager.CurrentGameState != GameManager.GameState.Playing) return;
        _anim.SetBool("IsRunning", true);

        if (Input.GetKeyDown(KeyCode.Space) && !_isJumping)
        {
            _jumped = true;
            _isJumping = true;
        }

        foreach (Touch touch in Input.touches)
        {
            if (touch.fingerId == 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    if (!_isJumping)
                    {
                        _jumped = true;
                        _isJumping = true;
                    }
                }

                if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    Debug.Log("First finger left.");
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ground")) return;
        _isJumping = false;
        _anim.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {
        if (gameManager.CurrentGameState == GameManager.GameState.Playing)
            _rb.position = new Vector2(transform.position.x + vel * Time.deltaTime, transform.position.y);


        if (!_jumped) return;
        _jumped = false;
        _rb.AddForce(new Vector2(0, 7), ForceMode2D.Impulse);
        _anim.SetBool("IsJumping", true);
    }
}