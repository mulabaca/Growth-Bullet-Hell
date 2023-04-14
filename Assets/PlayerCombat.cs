using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    // Start is called before the first frame update

    public GunScript gunScript;
    void Start()
    {
        gunScript = GetComponentInChildren<GunScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnFire(){
        gunScript.fireBullet();
    }


}
