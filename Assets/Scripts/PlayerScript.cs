using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody1;
    [SerializeField] float velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody1.velocity = moveVal * velocity; //sets velocity according to the input
    }

    Vector2 moveVal;
    void OnMove(InputValue val) //gets value from input and sticks it in a vec2 variable
    {
        moveVal = val.Get<Vector2>();
    }
}
