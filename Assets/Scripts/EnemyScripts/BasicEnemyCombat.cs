using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyCombat : MonoBehaviour
{

    public float health = 1f;
    // Start is called before the first frame update

    public float contactDamage = 0f;

    private LootHandler lootHandler;
    void Start()
    {
        lootHandler = GetComponent<LootHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision){
        Debug.Log("Enemy collision with " + collision.collider.tag);
        if(collision.collider.CompareTag("Bullet")){
            BulletScript bulletScript = collision.collider.GetComponent<BulletScript>();
            if(!bulletScript.isPassive() && bulletScript.isFromPlayer()){
                takeDamage(bulletScript);
                Debug.Log("Enemy took damage from " + collision.collider.tag + " owned by player: " + bulletScript.isFromPlayer());
            }
        }
    }

    private void takeDamage(BulletScript bulletScript){
        health -= bulletScript.bulletDamage;
        if(health <= 0f){

            GameObject loot = lootHandler.loot();
            if(loot != null){
                GameObject spawnedLoot = Instantiate(loot, transform.position, transform.rotation);
                spawnedLoot.transform.Rotate(0f,0f,90f);
            }
            Destroy(gameObject);
        }
        bulletScript.dealtDamage();
    }
}
