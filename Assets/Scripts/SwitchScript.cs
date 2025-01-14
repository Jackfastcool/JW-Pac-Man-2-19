using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    [SerializeField] GameObject activatorTarget;
    [SerializeField] Collider2D collider1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() //checks wether the collider is touching player, if so, activate the switch
    {
        if (collider1.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            switchActivate();
        }
    }

    void switchActivate() //runs the script in ActivatableScript.cs, with the integer code for the mode.
    {
        activatorTarget.GetComponent<ActivatableScript>().Activate(0);
    }
}
