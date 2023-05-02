using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAim : MonoBehaviour
{
    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        aimAtPlayer();
    }

    private void aimAtPlayer(){
        // Get the direction to the player
        Vector3 direction = playerTransform.position - transform.position;

        // Rotate the enemy to face the player
        transform.right = direction;
    }
}
