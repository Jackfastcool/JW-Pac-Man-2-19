using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlScript : MonoBehaviour
{

    [SerializeField] GameObject controllerTarget;
    [SerializeField] Collider2D collider1;
    [SerializeField] float setLocationX, setLocationY;

    public void SetCameraLocation(float x, float y)
    {
        gameObject.transform.position = new Vector2(x, y);
        // simply takes an input from another script and moves the object to that location
        // NOTE: this is the follow target for the Cinemachine Vcam - dampening is set stupidly high
        // to create the smooth transitions between rooms.
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    print("object entered camera control hitbox.");
    //    if (collider1.IsTouchingLayers(LayerMask.GetMask("Player")))
    //    {
    //        print("player detected.");
    //        GameObject.FindGameObjectWithTag("CameraController").GetComponent<CameraControlScript>().SetCameraLocation(setLocationX, setLocationY);
    //        // detects whether the player is in the collider and sends the target object to a new location.
    //        // NOTE: this does not trigger the SetCameraLocation() in THIS script due to being explicitly
    //        // called in another GameObject, so the GameObject that this script is attatched to either uses
    //        // SetCameraLocation OR this function.
    //    }
    //}   ---- NOTE: This function did not work, so I am using Update() instead. the functionality remains identical.

    private void Update()
    {
        try
        {
            if (collider1.IsTouchingLayers(LayerMask.GetMask("Player")))
            {
                //print("player detected.");
                GameObject.FindGameObjectWithTag("CameraController").GetComponent<CameraControlScript>().SetCameraLocation(setLocationX, setLocationY);
            }
        }
        catch
        {
            //no hitbox detected, so does this instead (nothing)
        }
    }
}
