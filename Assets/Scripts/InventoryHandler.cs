using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class InventoryHandler : MonoBehaviour
{
    private Dictionary<string, int> inventory;

    private int[] dictionary2 = {0,0,0}; //in DataType order 

    public Canvas uiCanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //add pickup to inventory if able to pay cost
    //returns true if requrements are met
    public bool addPickup2(PickupData data){
        if(payCost(data.cost)){
            dictionary2[(int)data.type2] += data.value;
            uiCanvas.GetComponentInChildren<UIScript>().updateCounter2(dictionary2[(int)data.type2], data.type2);
            return true;
        }
        return false;
    }

    public bool addEffectPickup(PickupData data){
        if(payCost(data.cost)){
            dictionary2[(int)data.type2] += data.value;
            uiCanvas.GetComponentInChildren<UIScript>().updateCounter2(dictionary2[(int)data.type2], data.type2);
            return true;
        }
        return false;
    }

    private bool payCost(int cost){
        if(dictionary2[(int)PickupType.Coin] >= cost){
            dictionary2[(int)PickupType.Coin] -= cost;
            uiCanvas.GetComponentInChildren<UIScript>().updateCounter2(dictionary2[(int)PickupType.Coin], PickupType.Coin);
            return true;
        }
        return false;

    }
}
