using UnityEngine;

public class CatController : MonoBehaviour
{
    [SerializeField] float vel;

    private Rigidbody2D rb;
    private Animator anim;
    private bool isJumping;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            rb.AddForce(new Vector2(2, 7), ForceMode2D.Impulse);
            anim.SetBool("IsJumping", true);
        }
       
        foreach (Touch touch in Input.touches)
        {

            if (touch.fingerId == 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    rb.AddForce(new Vector2 (2, 5), ForceMode2D.Impulse);
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
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            anim.SetBool("IsJumping", false);
        }
    }
    void FixedUpdate()
    {
        rb.position = new Vector2(transform.position.x + vel * Time.deltaTime, transform.position.y);
    }
}
