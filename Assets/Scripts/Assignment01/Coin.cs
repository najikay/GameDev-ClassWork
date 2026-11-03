using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue;
    public Color coinColor;
    
    void Start()
    {
        // get the sprite renderer component, then set its color values to the coinColor
        // (i.e. set the color on load according to the picked coin color)
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
        sr.color = coinColor;
    }
}
