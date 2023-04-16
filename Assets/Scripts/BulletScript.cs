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

    public float lifetime = 1;

    private bool collided = false;

    private bool dying = false;

    private SpriteRenderer spriteRenderer;

    private float alphaValue = 1f;

    private bool playerBullet;

    void Start()
    {
        rbBullet = GetComponent<Rigidbody2D>();
        hitbox = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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


    void FixedUpdate()
    {   
        if(!collided){
            rbBullet.velocity =  direction;
        }else if(dying && Time.time > lifetime){
            rbBullet.velocity =  Vector3.zero; //stop the bullet
            hitbox.isTrigger = true; //disable collisions
            spriteRenderer.sortingOrder = 0; //make them part of the background
            decreaseOpacity();
            
        }else if(dying){
            rbBullet.velocity = rbBullet.velocity * 0.95f;
        }
    } 
    
    //
    void OnCollisionEnter2D(Collision2D collision){
        if(!collided){
            collided = true;
            lifetime = Time.time + lifetime;
        }
        if(!collision.gameObject.CompareTag("Bullet")){ 
            dying = true;
        }
        
    }

    private void decreaseOpacity(){
        alphaValue -= 0.1f;
        // get the current color of the sprite
        Color currentColor = spriteRenderer.color;

        // set the alpha value of the color
        currentColor.a = alphaValue;

        // set the new color on the SpriteRenderer component
        spriteRenderer.color = currentColor;

        if (alphaValue <= 0){
            Destroy(gameObject);
        }
    }

    public void setMass(float mass){
        rbBullet.mass = mass;
    }

    public void setPlayerBullet(bool isPlayerBullet){
        playerBullet = isPlayerBullet;
    }
}