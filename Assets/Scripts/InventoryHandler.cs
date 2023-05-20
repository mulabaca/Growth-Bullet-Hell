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
    }

    public void addPickup(PickupData data){
        inventory[data.type] += data.value;
        uiCanvas.GetComponentInChildren<UIScript>().updateCoinCounter(inventory["coin"]);
    }
}
