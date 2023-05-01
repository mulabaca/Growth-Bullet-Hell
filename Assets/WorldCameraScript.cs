using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCameraScript : MonoBehaviour
{

    public GameObject player1;
    public GameObject player2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player2 == null){ //if single player
            transform.position = new Vector3(player1.transform.position.x, player1.transform.position.y, -10f);
        } 
        
    }
}
