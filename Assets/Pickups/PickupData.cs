using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupData : MonoBehaviour
{
    public string type;
    public int value, cost;
    public bool respawnable = false;

    private SpriteRenderer spriteRenderer;



    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (respawnable){
            

            //TODO:
            //set visibility
            //set collider to isTrigger
            
        }
    }
}
