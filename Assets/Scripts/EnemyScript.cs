using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    [SerializeField] GameObject followTarget;
    [SerializeField] Rigidbody2D rigidbody1;
    [SerializeField] Collider2D collider1;
    [SerializeField] int enemyMode; // 1 - random direction once hit wall | 2 - follow player directly
    [SerializeField] float veloctiy;

    float currentRotation;

    // Awake is called when the object is created
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyMode == 1)
        {
            currentRotation = rigidbody1.rotation;
            if (collider1.IsTouchingLayers(LayerMask.GetMask("Wall")))
            {
                rigidbody1.SetRotation(currentRotation + (Mathf.Sign(Random.Range(-1,1)) * 90));
                // this line takes a random number between 1 and -1 and uses Mathf.Sign() to generate an absolute
                // value - Mathf.Abs will just return the positive number - which is then mulitplied by 90 to then
                // be used to add onto the rotation of the gameObject, and then added onto currentRotation so that
                // this is repeatable.
            }
        }
        else if (enemyMode == 2)
        {
            Vector3 followPos = followTarget.transform.position;
            rigidbody1.SetRotation(Quaternion.LookRotation(Vector3.forward, followPos - transform.position));
            // this handy little bit of code takes the transform position of the followTarget and turns it into
            // a "lookRotation", which is the quaternion required for the gameObject to have in order to look
            // at the followTarget. setting the rotation is a simple task but this is condensed for efficiency.
        }

        rigidbody1.velocity = gameObject.transform.up * veloctiy;
    }

    
}
