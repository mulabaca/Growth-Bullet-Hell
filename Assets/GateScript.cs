using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour
{

    private Transform gate;

    private bool opened = false;


    // Start is called before the first frame update
    void Start()
    {
        gate = transform.GetChild(0);
    }

    public void Open(){
        if(!opened){
            gate.localPosition = new Vector3(gate.localPosition.x - gate.localScale.x, gate.localPosition.y);
            opened = true;
        }
    }

    public void Close(){
        if(opened){
            gate.localPosition = new Vector3(gate.localPosition.x + gate.localScale.x, gate.localPosition.y);
            opened = false;
        }
    }
}
