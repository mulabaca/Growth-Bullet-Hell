using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class look : MonoBehaviour
{

    public float rotateSpeed = 10f;

    private Vector2 lookInput;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //check for input device from settings
    }

    void OnLook(InputValue value){
        
        lookInput = value.Get<Vector2>();
        if(Mathf.Abs(lookInput.x) > 0.3f || Mathf.Abs(lookInput.y) > 0.3f){
            stickRotate();
        }
        
    }

    private void stickRotate(){
        float angle = Mathf.Atan2(lookInput.y, lookInput.x) * Mathf.Rad2Deg;
            rb.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
