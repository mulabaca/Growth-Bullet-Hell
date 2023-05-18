using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnDummy : MonoBehaviour
{
    public GameObject dummyPrefab;

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
            Debug.Log("POOF!");
            GameObject dummy = Instantiate(dummyPrefab, new Vector3(8,0,0), transform.rotation);
            //dummy.GetComponent<AIDestination>();
        }
    }
}
