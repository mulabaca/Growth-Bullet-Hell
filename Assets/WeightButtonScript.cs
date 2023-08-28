using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightButtonScript : MonoBehaviour
{
    public GameObject interactable;

    public float sizeRequrement;

    public RequirementType requirementType;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("Player")){
            if(ValidateSize(collider.transform.localScale.x)){
                interactable.GetComponent<GateScript>().Open();
            }
        }
    }

    private bool ValidateSize(float playerSize){
        switch (requirementType)
        {
            case RequirementType.Equal:
                return (playerSize == sizeRequrement);
            case RequirementType.Minimum:
                return (playerSize >= sizeRequrement);
            case RequirementType.Maximum:
                return (playerSize <= sizeRequrement);
            default:
                return false;
        }
    }
}

public enum RequirementType{
    Minimum,
    Maximum,
    Equal
}
