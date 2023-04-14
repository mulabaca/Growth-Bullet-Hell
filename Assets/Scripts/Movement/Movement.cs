using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{

    private Vector2 playerinput;
    private Rigidbody2D rb;

    public Vector2 velocity;
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velocity = rb.velocity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = (playerinput * speed);
        velocity = rb.velocity;
    }   

    void OnMove(InputValue value){
        playerinput = value.Get<Vector2>();
    }
    
}
