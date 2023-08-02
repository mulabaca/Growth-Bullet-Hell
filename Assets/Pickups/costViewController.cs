using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class costViewController : MonoBehaviour
{
    private PickupData pickupData;
    private TextMeshPro text;
    // Start is called before the first frame update
    void Start()
    {
        pickupData = GetComponent<PickupData>();
        text = GetComponentInChildren<TextMeshPro>();
        updateCost();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateCost(){
        if(pickupData != null && pickupData.cost > 0){
            text.enabled = true;
            text.SetText(pickupData.cost.ToString());
        }else text.enabled = false;
        
    }
}
