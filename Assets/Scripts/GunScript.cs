using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{

    public GameObject bulletPrefab;

    public float fireRate = 1f; //cannot be 0

    public float bulletSpeed = 10f; 

    public float momentumStrength = 1f;

    public float bulletMass = 0.2f;

    public float recoil;

    public bool playerBullet;

    private bool isEquipped = false;

    private BoxCollider2D gunHitbox;

    private float nextFireTime = 0f;


    private BulletScript bulletScript;
    

    public Rigidbody2D rbPlayer;

    public Movement playerMovementScript;

    private InputHintScript inputHintScript;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponentInParent<Rigidbody2D>();   
        gunHitbox = GetComponent<BoxCollider2D>();
        inputHintScript = GetComponentInChildren<InputHintScript>();
        audioSource = GetComponent<AudioSource>();

        if(transform.parent != null){
            playerBullet = transform.parent.CompareTag("Player");
            if(playerBullet){
                Debug.Log("Player shooting");
                playerMovementScript = GetComponentInParent<Movement>();  
                isEquipped = true;
                gunHitbox.enabled = false;
            }
            else if(transform.parent.CompareTag("Enemy")){
                isEquipped = true;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void fireBullet()
    {
        //Debug.Log("Fire time: " + nextFireTime);
        // Check if the gun is equipped and enough time has passed since last firing a bullet
        if (!isEquipped || Time.time < nextFireTime){
            return; //don't shoot
        } //else shoot

        // Create a new bullet from the bullet prefab
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

        // Set the bullet's velocity and direction
        
        bulletScript = bullet.GetComponent<BulletScript>();

        bulletScript.setPlayerBullet(playerBullet);                     //bullet owner
        bulletScript.SetBulletSpeed(bulletSpeed);                       //bullet speed
        bulletScript.SetMomentum(rbPlayer.velocity * momentumStrength); //bullet momentum
        bulletScript.transform.localScale *= transform.lossyScale.x;
        Debug.Log("recoil: " + recoil);

        //bulletScript.setMass(bulletMass);                               //bullet mass

        audioSource.Play();                                              //audio

        if (playerMovementScript != null){
            playerMovementScript.setRecoil(recoil);                         //recoil
            Debug.Log("recoil: " + recoil);
        }else{
            //enemy recoil  
        } 

        // Update the next time it can fire
        nextFireTime = Time.time + (1f/fireRate);
    }

    void OnTriggerEnter2D(Collider2D collider){
        if (collider.CompareTag("Player")){
            collider.GetComponent<PlayerCombat>().weaponOnReach = gameObject;
            inputHintScript.show();
        }
    }

    void OnTriggerExit2D(Collider2D collider){
        if (collider.CompareTag("Player")){
            collider.GetComponent<PlayerCombat>().weaponOnReach = null;
            inputHintScript.hide();
        }
    }

    public void equip(Transform player, Vector3 position, Quaternion rotation){
        //Debug.LogWarning("Equipping: " + gameObject.name);
        inputHintScript.hide();
        transform.SetParent(player);
        playerMovementScript = GetComponentInParent<Movement>(); 
        rbPlayer = GetComponentInParent<Rigidbody2D>();
        isEquipped = true;
        gunHitbox.enabled = false;
        playerBullet = true;
        transform.localPosition = position;
        transform.localRotation = rotation;
        transform.localScale = new Vector3(1f,1f,1f);
        
    }

    public void unequip(){
        //Debug.LogWarning("Unequipping: " + gameObject.name);
        transform.SetParent(transform.parent.transform.parent);
        playerMovementScript = null; 
        isEquipped = false;
        gunHitbox.enabled = true;
        playerBullet = false;
        inputHintScript.show();
    }
}
