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

    private float nextFireTime = 0f;


    private BulletScript bulletScript;
    

    public Rigidbody2D rbPlayer;

    public Movement playerMovementScript;

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponentInParent<Rigidbody2D>();   
        playerBullet = transform.parent.CompareTag("Player");
        if(transform.parent.CompareTag("Player")){
            Debug.Log("Player shooting");
            playerMovementScript = GetComponentInParent<Movement>();  
        }else{
            Debug.Log("Enemy shooting: " + playerBullet);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    //checks if the gun is equiped
    public bool isEquipped()
    {
        return transform.parent != null;
    }

    public void fireBullet()
    {
        //Debug.Log("Fire time: " + nextFireTime);
        // Check if the gun is equipped and enough time has passed since last firing a bullet
        if (!isEquipped() || Time.time < nextFireTime)
        {
            return; //don't shoot
        } //else shoot

        // Create a new bullet from the bullet prefab
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

        // Set the bullet's velocity and direction
        
        bulletScript = bullet.GetComponent<BulletScript>();

        bulletScript.SetBulletSpeed(bulletSpeed);                       //bullet speed
        bulletScript.setMomentum(rbPlayer.velocity * momentumStrength); //bullet momentum
        bulletScript.setPlayerBullet(playerBullet);                     //bullet owner
        bulletScript.transform.localScale *= transform.lossyScale.x;
        Debug.Log("recoil: " + recoil);

        //bulletScript.setMass(bulletMass);                               //bullet mass

        if (playerMovementScript != null){
            playerMovementScript.setRecoil(recoil);                         //recoil
            Debug.Log("recoil: " + recoil);
        }else{
            //enemy recoil  
        } 

        // Update the next time it can fire
        nextFireTime = Time.time + (1f/fireRate);
    }
}
