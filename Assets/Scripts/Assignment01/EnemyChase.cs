using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public float speed = 2.0f;
    private Rigidbody2D rb;
    private Rigidbody2D playerRb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // get direction towards player in a 2D vector, then move towards it
        Vector2 direction = (playerRb.position - rb.position).normalized;
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }
}
