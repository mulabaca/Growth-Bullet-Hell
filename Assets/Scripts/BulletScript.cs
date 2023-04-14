using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody2D rbBullet;
    public float bulletSpeed;

    public Vector3 newDirection;

    public Vector3 direction;

    private CircleCollider2D hitbox;

    private bool collided = false;

    void Start()
    {
        rbBullet = GetComponent<Rigidbody2D>();
        hitbox = GetComponent<CircleCollider2D>();
    }

    public void SetBulletSpeed(float speed)
    {
        bulletSpeed = speed;
        direction = (transform.right * bulletSpeed);
    }

    public void setMomentum(Vector3 momentum){
        float projection = Vector3.Dot(momentum, direction.normalized);
        newDirection = (direction.normalized * (projection/2));
        direction = (transform.right * bulletSpeed) + newDirection;
    }

    public void shoot(){
        
    }

    void FixedUpdate()
    {   
        if(!collided){
            rbBullet.velocity =  direction;
        }
    } 

    void OnCollisionEnter2D(Collision2D collision){
        collided = true;
    }
    
}