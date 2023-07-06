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
    private float sizeDamageMultiplyer = 1.2f; //multipliyer for player size after taking damage

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
                takeDamage();
                bulletScript.dealtDamage();
            }
        }//enemies
        else if(collision.collider.CompareTag("Enemy")){
            takeDamage();
        }
    }

    private void takeDamage(){
        if (cooldown <= Time.time){
            multiplySize(sizeDamageMultiplyer);
            cooldown = Time.time + damageCooldown;
        }
        
    }
    //adds size to player
    //size : float  is the change it will get.
    public void addSize(float size){
        transform.localScale = new Vector3(transform.localScale.x + size, transform.localScale.y + size, 1f);
    }

    //scale size of player
    public void multiplySize(float multipliyer){
        transform.localScale = new Vector3(transform.localScale.x * multipliyer, transform.localScale.y * multipliyer, 1f);
    }
}
