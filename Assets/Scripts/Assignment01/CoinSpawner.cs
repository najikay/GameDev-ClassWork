using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject[] coinPrefabs;
    public int coinsPerBatch = 5;
    public Vector2 minPosition;
    public Vector2 maxPosition;

    // we'll use a counter for the coins instead of holding an entire array of game objects
    private int coinsLeft;

    private void SpawnCoinBatch()
    {
        for (int i = 0; i < coinsPerBatch; i++)
        {
            // use Random to pick a coin prefab randomly (use the index of the coinPrefabs to pick a coin at random)
            int randCoin = Random.Range(0, coinPrefabs.Length);
            // get a random position between min and max positions for each coordinate
            Vector2 randPosition = new Vector2(Random.Range(minPosition.x, maxPosition.x), Random.Range(minPosition.y, maxPosition.y));
            // spawn the coin
            Instantiate(coinPrefabs[randCoin], randPosition, Quaternion.identity);
        }
        coinsLeft = coinsPerBatch;
    }

    public void CoinCollected()
    {
        coinsLeft -= 1;
        if (coinsLeft == 0)
        {
            SpawnCoinBatch();
        }
    }
    
    void Start()
    {
        SpawnCoinBatch();
    }
}
