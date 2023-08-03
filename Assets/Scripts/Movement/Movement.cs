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

    public MovementType movementType = MovementType.move;

    private float dashCoolDownTime;

    private float movementTimeLock;

    public float dashCoolDown = 0.5f;

    public float dashMultiplier = 3f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velocity = rb.velocity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        switch (movementType)
        {
            case MovementType.move:
                moveNormally();
                return;
            
            case MovementType.dash:
                dash();
                return;
            
            default:
                return;
        }
    }   

    public void OnMove(InputValue value){
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

    void OnDash(){
        if (Time.time > dashCoolDownTime){

            Vector2 newVelocity = playerinput;

            Vector2 amplifiedVelocity = new Vector2(
                Mathf.Sign(newVelocity.x) * Mathf.Clamp(Mathf.Abs(newVelocity.x) * 3, 0f, 1f),
                Mathf.Sign(newVelocity.y) * Mathf.Clamp(Mathf.Abs(newVelocity.y) * 3, 0f, 1f)
            );
            
            movementType = MovementType.dash;
            rb.velocity = amplifiedVelocity*speed* transform.localScale.y * dashMultiplier;
            movementTimeLock = Time.time + 0.2f;
        }
    }

    private void moveNormally(){
        if(recoil > speed/20){ //if recoil bigger than 5% of player speed
            //apply recoil to player velocity
            rb.velocity = (playerinput * speed * transform.localScale.y) + recoilVector;
            reduceRecoil();
        }else{
            rb.velocity = (playerinput * speed * transform.localScale.y);
        }
        velocity = rb.velocity;
    }

    private void dash(){
        if(Time.time > movementTimeLock){
            movementType = MovementType.move;
            dashCoolDownTime = Time.time + dashCoolDown;
        }

    }
    
}

  public enum MovementType
    {
        move,
        dash,
        stun,
        slide
    }


