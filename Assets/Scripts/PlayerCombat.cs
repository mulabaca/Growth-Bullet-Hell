using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    // Start is called before the first frame update
    private bool pressingFire {get; set;}

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
                takeDamage(bulletScript);
            }
        }
    }

    private void takeDamage(BulletScript bulletScript){
        addSize(bulletScript.bulletDamage);
        bulletScript.dealtDamage();
    }

    private void addSize(float size){
        transform.localScale = new Vector3(transform.localScale.x + size, transform.localScale.y + size, 1f);
    }
}
