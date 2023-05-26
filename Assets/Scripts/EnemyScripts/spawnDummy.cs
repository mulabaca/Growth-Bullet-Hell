using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnDummy : MonoBehaviour
{
    public GameObject commonSpawn;

    public float randomXRangeLow, randomXRangeHigh;
    public float randomYRangeLow, randomYRangeHigh;
    private int count = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            float spawnpointx, spawnpointy;
            
            for (int i = 0; i < count; i++)
            {

                //randomize position
                spawnpointx = Random.Range(randomXRangeLow, randomXRangeHigh);
                spawnpointy = Random.Range(randomYRangeLow, randomYRangeHigh);

                //randomize direction
                if(Random.value < 0.5f){
                    spawnpointx *= -1;
                }
                if(Random.value < 0.5f){
                    spawnpointy *= -1;
                }

                Debug.Log("POOF!");
                GameObject dummy = Instantiate(commonSpawn, new Vector3(spawnpointx ,spawnpointy ,0), transform.rotation);
            }
            count += 1;
        }
    }
}
