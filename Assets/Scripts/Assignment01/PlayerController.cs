using UnityEngine;
using UnityEngine.InputSystem;
using UnityEditor;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private Vector2 direction;
    private Rigidbody2D rb;
    
    public int targetScore = 1000;
    private int currentScore = 0;
    private bool hasWon = false;
    private CoinSpawner coinSpawner;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // player caught (player lost)
            Debug.Log("you lose");
            // Yakir's suggestion from discord (stops the gameplay)
            EditorApplication.isPlaying = false;
        }
        else if (other.CompareTag("Coin"))
        {
            // get the coin's value and add it to the score
            currentScore += other.GetComponent<Coin>().coinValue;
            // delete the coin once its value is added to the score
            Destroy(other.gameObject);
            // call the coin collected method from the coin spawner
            // it spawns more coins if all the current coins are collected
            coinSpawner.CoinCollected();

            // we use the hasWon flag so we can check if the player already won, so we won't print the win message again
            if (currentScore >= targetScore && !hasWon)
            {
                // we reached the win condition (player won)
                hasWon = true;
                Debug.Log("you won");
                // Yakir's suggestion from discord (stops the gameplay)
                EditorApplication.isPlaying = false;
            }
        }
    }

    void Start()
    {
        // load rigidbody
        rb = GetComponent<Rigidbody2D>();
        
        // get a coin spawner reference to have access to coin collected method
        coinSpawner = GameObject.FindGameObjectWithTag("CoinSpawner").GetComponent<CoinSpawner>();
    }

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
