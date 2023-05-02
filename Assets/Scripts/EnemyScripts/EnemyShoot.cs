using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public float range = 100f;
    
    public EnemyAim aimScript;

    private GunScript shootScript;
    // Start is called before the first frame update
    void Start()
    {
        shootScript = GetComponentInChildren<GunScript>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(aimScript.playerTransform.position, transform.position);
        if(distance <= range){
            shootScript.fireBullet();
        }
    }
}
