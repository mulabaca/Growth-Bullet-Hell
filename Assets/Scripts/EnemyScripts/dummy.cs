using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is a practice enemy
public class dummy : MonoBehaviour
{

    private float health;
    public float maxHealth;
    private float speed;
    private float firerate;
    private float invincible;

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        //invincibility();
    }
    
    //On collision with an object it will call the tag of the object out and if the object is a bullet and is no invincible will take damage.
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Bullet")
        {
            //Debug.Log(col.gameObject.tag);
            //Debug.Log(health);
            if(invincible == 0)
            {
               health = health - 1;
               //invincible = invincible + 1000;
            }

            if(health <= 0)
            {
                Debug.Log("Enemy Destroyed!");
                Destroy(gameObject);
            }
        }
    }

    //This is a test for invincibility frames.
    public void invincibility()
    {
        if(invincible > 0)
        {
            invincible -= 1;
            //Debug.Log(invincible);
        }
    }
}
