using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private Vector2 direction;
    private Rigidbody2D rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // read the WASD keys each frame
        float aVal, dVal, wVal, sVal;
        aVal = Keyboard.current.aKey.value;
        dVal = Keyboard.current.dKey.value;
        wVal = Keyboard.current.wKey.value;
        sVal = Keyboard.current.sKey.value;
        
        // put the values in a vector and normalize
        direction = new Vector2(dVal - aVal, wVal - sVal).normalized;
    }

    private void FixedUpdate()
    {
        // apply the movement (fixed time delta)
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }
}
