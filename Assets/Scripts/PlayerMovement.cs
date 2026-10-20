using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var dValue = Keyboard.current.dKey.value;
        gameObject.transform.position += dValue * Vector3.right * speed * Time.deltaTime;
        
        var aValue = Keyboard.current.aKey.value;
        gameObject.transform.position += aValue * Vector3.left * speed * Time.deltaTime;
        
        var wValue = Keyboard.current.wKey.value;
        gameObject.transform.position += wValue * Vector3.up * speed * Time.deltaTime;
        
        var sValue = Keyboard.current.sKey.value;
        gameObject.transform.position += sValue * Vector3.down * speed * Time.deltaTime;
        
    }
}
