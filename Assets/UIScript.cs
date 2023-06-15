using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public TextMeshProUGUI coinCounter;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //updates ui counter corresponding pickup
    public void updateCounter(int count, string type){

        if(type == "coin"){
            coinCounter.SetText(count.ToString());
        }
    }


}
