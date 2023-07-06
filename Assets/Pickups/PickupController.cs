using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    PickupData pickupData;
    
    PickupEffect pickupEffect;

    private int buyCooldown = 0;
    void Start()
    {
        pickupData = GetComponent<PickupData>();
        pickupEffect = GetComponent<PickupEffect>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        if(col.gameObject.tag == "Player")
        {
            //check buy cooldown
            if (pickupData.respawnable && buyCooldown > ((int)Time.time)){
                return;
            }

            //if not in cooldown
            InventoryHandler inventoryHandler = col.gameObject.GetComponent<InventoryHandler>();
            
            if(inventoryHandler.addPickup(pickupData)){ //if cost paid

                if(pickupEffect != null){ //apply effect if any
                    pickupEffect.applyEffects(col.gameObject);
                }

                if(!pickupData.respawnable){ //destroy
                    Destroy(gameObject);
                }
                else{ //respawn
                    buyCooldown = ((int)Time.time) + 2;
                }
            }
        }
    }
}
