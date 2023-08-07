using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHintScript : MonoBehaviour
{
    // Start is called before the first frame update

    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
       //TODO: get correct input sprite 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void show(){
        spriteRenderer.enabled = true;
    }

    public void hide(){
        spriteRenderer.enabled = false;
    }
}
