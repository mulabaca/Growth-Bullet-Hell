using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    // Start is called before the first frame update
    private bool pressingFire {get; set;}

    public GunScript gunScript;

    public InputAction fire;
    void Start()
    {
        gunScript = GetComponentInChildren<GunScript>();
        fire = GetComponent<PlayerInput>().actions["Fire"];
    }

    // Update is called once per frame
    void Update()
    {
        if(fire.IsPressed()){
            gunScript.fireBullet();
        }
    }

    


}
