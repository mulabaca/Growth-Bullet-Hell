using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    // Start is called before the first frame update
    private bool pressingFire {get; set;}

    public float damageCooldown = 1f;

    private float cooldown = 0f;

    public GunScript gunScript;

    public InputAction fire;

    void Start()
    {
        gunScript = GetComponentInChildren<GunScript>();
        fire = GetComponent<PlayerInput>().actions["Fire"];
    }

    // Update is called once per frame
    void Update()
    {
        if(fire.IsPressed()){
            gunScript.fireBullet();
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        //Debug.Log("Player collision with " + collision.collider.tag);
        if(collision.collider.CompareTag("Bullet")){
            BulletScript bulletScript = collision.collider.GetComponent<BulletScript>();
            if(!bulletScript.isPassive() && !bulletScript.isFromPlayer()){
                Debug.Log("Player took damage!");
                takeDamage(bulletScript.bulletDamage);
                bulletScript.dealtDamage();
            }
        }
        else if(collision.collider.CompareTag("Enemy")){
            takeDamage(collision.collider.GetComponent<BasicEnemyCombat>().contactDamage);
        }
        //
        else if(collision.collider.CompareTag("Pickup")){
            GetComponent<InventoryHandler>().addPickup(collision.collider.GetComponent<PickupData>()); 
            Destroy(collision.collider.gameObject); 
        }
    }

    private void takeDamage(float damage){
        if (cooldown <= Time.time){
            addSize(damage);
            cooldown = Time.time + damageCooldown;
        }
        
    }

    private void addSize(float size){
        transform.localScale = new Vector3(transform.localScale.x + size, transform.localScale.y + size, 1f);
    }
}
