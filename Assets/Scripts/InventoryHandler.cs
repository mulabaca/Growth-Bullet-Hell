using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHandler : MonoBehaviour
{
    private Dictionary<string, int> inventory;

    public Canvas uiCanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        inventory = new Dictionary<string, int>();
        inventory["coin"] = 0;
        inventory["key"] = 0;
    }

    public bool addPickup(PickupData data){
        if(payCost(data.cost)){
            inventory[data.type] += data.value;
            uiCanvas.GetComponentInChildren<UIScript>().updateCounter(inventory[data.type], data.type);
            return true;
        }
        return false;
    }

    private bool payCost(int cost){
        if(inventory["coin"] >= cost){
            inventory["coin"] -= cost;
            return true;
        }
        return false;

    }
}
