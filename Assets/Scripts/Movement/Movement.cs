using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{

    private Vector2 playerinput;
    private Rigidbody2D rb;

    public Vector2 velocity;
    public float speed = 10f;

    public float recoil;

    public Vector2 recoilVector;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velocity = rb.velocity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(recoil > speed/10){ //if recoil bigger than 10% of player speed
            //apply recoil to player velocity
            rb.velocity = (playerinput * speed) + recoilVector;
            reduceRecoil();
        }else{
            rb.velocity = (playerinput * speed);
        }
        velocity = rb.velocity;
    }   

    void OnMove(InputValue value){
        playerinput = value.Get<Vector2>();
    }

    public void setRecoil(float recoilGiven){
        recoil = recoilGiven;
        recoilVector = new Vector2((Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.z) * -recoil), Mathf.Sin(Mathf.Deg2Rad * transform.eulerAngles.z) * -recoil);
        //Debug.Log("recoil set");
    }

    private void reduceRecoil(){
        recoil *= 0.5f;
    }
    
}
