using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody1;
    [SerializeField] float velocity;
    [SerializeField] Collider2D collider1;

    GameObject[] enemyList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody1.velocity = moveVal * velocity; //sets velocity according to the input
        if (collider1.IsTouchingLayers(LayerMask.GetMask("Pickup")))
        {
            print("collectible detected");
            enemyList = GameObject.FindGameObjectsWithTag("Enemy");
            print(enemyList);
            foreach (GameObject enemy in enemyList)
            {
                enemy.GetComponent<EnemyScript>().SetVunerable(true);

            }
        }
    }

    Vector2 moveVal;
    void OnMove(InputValue val) //gets value from input and sticks it in a vec2 variable
    {
        moveVal = val.Get<Vector2>();
    }
}
