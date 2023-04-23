using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class look : MonoBehaviour
{

    public float rotateSpeed = 10f;

    private Vector2 lookInput;

    private Rigidbody2D rb;

    public bool usingMouse = true;

    public GameObject worldCamera;

    private Camera realCamera;

    // Start is called before the first frame update
    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        realCamera = worldCamera.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //check for input device from settings
        if (usingMouse){
            mouseRotate();
        }else {
            
            stickRotate();
            
        }
    }

    void OnLook(InputValue value){
        
        lookInput = value.Get<Vector2>();
    }

    private void stickRotate(){
        float angle = Mathf.Atan2(lookInput.y, lookInput.x) * Mathf.Rad2Deg;
            rb.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void mouseRotate(){

        //get pointer position
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        mousePosition = realCamera.ScreenToWorldPoint(mousePosition);

        // Get the direction to the player
        mousePosition = mousePosition - (new Vector2(transform.position.x, transform.position.y));

        Vector3 direction = new Vector3(mousePosition.x, mousePosition.y, 0f);

        transform.right = direction;
    }
}
