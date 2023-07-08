using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootHandler : MonoBehaviour
{
    public List<GameObject> lootPool;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject loot(){
        if(lootPool.Count > 0){
            return lootPool[lootEquation()]; 
        }
        else return null;
        
    }

    private int lootEquation(){
        return 0; //temporary loot getting 
    }
}
