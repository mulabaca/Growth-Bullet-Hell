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

    private InventoryHandler inventoryHandler;

    void Start()
    {
        gunScript = GetComponentInChildren<GunScript>();
        fire = GetComponent<PlayerInput>().actions["Fire"];
        
        inventoryHandler = GetComponent<InventoryHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if(fire.IsPressed()){
            gunScript.fireBullet();
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        //bullets
        if(collision.collider.CompareTag("Bullet")){
            BulletScript bulletScript = collision.collider.GetComponent<BulletScript>();
            if(!bulletScript.isPassive() && !bulletScript.isFromPlayer()){
                Debug.Log("Player took damage!");
                takeDamage(bulletScript.bulletDamage);
                bulletScript.dealtDamage();
            }
        }//enemies
        else if(collision.collider.CompareTag("Enemy")){
            takeDamage(collision.collider.GetComponent<BasicEnemyCombat>().contactDamage);
        }
    }

    private void takeDamage(float damage){
        if (cooldown <= Time.time){
            addSize(damage);
            cooldown = Time.time + damageCooldown;
        }
        
    }
    //adds size to player
    //size : float  is the change it will get.
    public void addSize(float size){
        transform.localScale = new Vector3(transform.localScale.x + size, transform.localScale.y + size, 1f);
    }
}
