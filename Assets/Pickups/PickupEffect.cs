using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupEffect : MonoBehaviour
{
    PickupData pickupData;
    // Start is called before the first frame update

    public bool sizeDownHalf;

    void Start()
    {
        pickupData = GetComponent<PickupData>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void applyEffects(GameObject player){

        //size
        PlayerCombat playerCombat = player.GetComponent<PlayerCombat>();
        if(sizeDownHalf){
            playerCombat.multiplySize(0.6f);
        }

    }
}
