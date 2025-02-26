using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpForce = 16f;
    Rigidbody2D rb;
    bool isGrounded;
    Transform currentCheckpoint;
    //public int PlayerLife = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    { 
        if (isGrounded) { 
            float moveX = Input.GetAxis("Horizontal");
            rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);
            
            bool jump = Input.GetButtonDown("Jump");
            if (jump)
            { 
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
            
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform;
            collision.GetComponent<Collider2D>().enabled = false;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player is grounded
        if (collision.gameObject.CompareTag("Structure"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.tag == "Void")
        {
            PlayerRespawn spawner = FindFirstObjectByType<PlayerRespawn>();
            if (spawner != null)
            {
                spawner.Respawn(currentCheckpoint);
            }

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Structure"))
        {
            isGrounded = false;
        }
    }
}
