using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody2D rbBullet;
    public float bulletSpeed;

    public float bulletDamage;

    public Vector3 newDirection;

    public Vector3 direction;

    private CircleCollider2D hitbox;

    public float lifetime = 1;

    public bool piercing;

    private bool collided {get; set;}

    private bool dying = false;

    private SpriteRenderer spriteRenderer;

    private float alphaValue = 1f;

    private bool playerBullet;

    private bool dealDamage = true;


    void Start()
    {
        collided = false;
        rbBullet = GetComponent<Rigidbody2D>();
        hitbox = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetBulletSpeed(float speed)
    {
        bulletSpeed = speed;
        direction = (transform.right * bulletSpeed);
    }

    public void SetMomentum(Vector3 momentum){
        float projection = Vector3.Dot(momentum, direction.normalized);
        newDirection = (direction.normalized * (projection/2));
        direction = (transform.right * bulletSpeed) + newDirection;
    }


    void FixedUpdate()
    {   

        if(!collided){
            rbBullet.velocity =  direction;
        }else if(dying && Time.time > lifetime){
            dealDamage = false;
            rbBullet.velocity =  Vector3.zero; //stop the bullet
            hitbox.isTrigger = false; //disable collisions
            spriteRenderer.sortingOrder = 0; //make them part of the background
            DecreaseOpacity();
            
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
        if(!collision.collider.CompareTag("Bullet")){ 
            dying = true;
        }
        
    }

    void OnTriggerEnter2D(Collider2D collider){

        if(!piercing){
            collided = true;
            Stick(collider.transform);
        }
        
        if(collider.CompareTag("Enemy")){

            collider.GetComponent<BasicEnemyCombat>().takeDamage(this);
        }
        
    }

    private void DecreaseOpacity(){
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

    public void SetMass(float mass){
        rbBullet.mass = mass;
    }

    public void setPlayerBullet(bool isPlayerBullet){
        playerBullet = isPlayerBullet;
        if(playerBullet){
            gameObject.layer = LayerMask.NameToLayer("PlayerBullet");
        }else{
            gameObject.layer = LayerMask.NameToLayer("Bullet");
        }
    }

    public bool IsPassive(){
        return !dealDamage;
    }

    public void DealtDamage(){
        dealDamage = false;
    }

    public bool IsFromPlayer(){
        return playerBullet;
    }

    private void Stick(Transform colliderTransform){

        GetComponent<CircleCollider2D>().enabled = false;
        transform.SetParent(colliderTransform);

        rbBullet.velocity = Vector2.zero;
    }
}