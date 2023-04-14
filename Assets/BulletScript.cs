using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody2D rbBullet;
    public float bulletSpeed;

    public Vector3 newDirection;

    public Vector3 direction;

    void Start()
    {
        rbBullet = GetComponent<Rigidbody2D>();
    }

    public void SetBulletSpeed(float speed)
    {
        bulletSpeed = speed;
        direction = (transform.right * bulletSpeed);
    }

    public void setMomentum(Vector3 m){
        float projection = Vector3.Dot(m, direction.normalized);
        newDirection = (direction.normalized * projection);
        direction = (transform.right * bulletSpeed) + newDirection;
    }

    public void shoot(){
        
    }

    void FixedUpdate()
    {   
        rbBullet.velocity =  direction;
    } 
}