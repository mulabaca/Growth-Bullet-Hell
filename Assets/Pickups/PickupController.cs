using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    PickupData pickupData;
    // Start is called before the first frame update
    void Start()
    {
        pickupData = GetComponent<PickupData>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            InventoryHandler inventoryHandler = col.gameObject.GetComponent<InventoryHandler>();
            
            if(inventoryHandler.addPickup(pickupData) && !pickupData.respawnable){
                Destroy(gameObject);
            }
        }
    }
}
