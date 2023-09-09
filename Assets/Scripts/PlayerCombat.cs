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

    private Camera worldCamera;

    public GameObject weaponOnReach;
    

    void Start()
    {
        gunScript = GetComponentInChildren<GunScript>();
        fire = GetComponent<PlayerInput>().actions["Fire"];
        
        inventoryHandler = GetComponent<InventoryHandler>();

        worldCamera = GetComponent<look>().worldCamera.GetComponent<Camera>();
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
            if(!bulletScript.IsPassive() && !bulletScript.IsFromPlayer()){
                Debug.Log("Player took damage!");
                takeDamage();
                bulletScript.DealtDamage();
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
   

    //scale size of player
    public void multiplySize(float multipliyer){
        transform.localScale = new Vector3(transform.localScale.x * multipliyer, transform.localScale.y * multipliyer, 1f);
        worldCamera.orthographicSize *= multipliyer;
    }

    void OnEquip(){
        //Debug.LogWarning("Equip pressed!");
    
        if(weaponOnReach != null){
            Transform currentWeapon = transform.GetChild(0); // change this if I add weapon switching

            Vector3 previousPos = currentWeapon.localPosition;
            Quaternion previousRot = currentWeapon.localRotation;
            gunScript.unequip();

            gunScript = weaponOnReach.GetComponent<GunScript>();
            gunScript.equip(transform, previousPos, previousRot);
            

        }
        
    }

    void OnDash(){
        cooldown = Time.time + 0.3f;
    }
}
