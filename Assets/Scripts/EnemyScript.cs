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
    [SerializeField] float vunerableTime;

    float currentRotation;
    bool vunerable;

    SpriteRenderer spriteRenderer;

    // Awake is called when the object is created
    void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        // finds the SpriteRenderer on this gameObject
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
                // value - Mathf.Abs() will just return the positive number - which is then mulitplied by 90 to then
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
        // sets the forward velocity to the relative up.

        if (vunerable)
        {
            spriteRenderer.color = Color.cyan;
            if (collider1.IsTouchingLayers(LayerMask.GetMask("Player")))
            {
                gameObject.SetActive(false);
            }
            // small bit of code for enemy death.
        }
        else
        {
            spriteRenderer.color = Color.HSVToRGB(0.06f, 1, 1);

            if (collider1.IsTouchingLayers(LayerMask.GetMask("Player")))
            {
                followTarget.GetComponent<PlayerScript>().Death();                
            }
            // if the collider is touching the player while not vunerable, it will call the Death() function in
            // PlayerScript. NOTE: followTarget is used as that is the player and needs to be set even if EnemyMode
            // == 1.
        }
        // sets the sprite colour to a blue to indicate vunerability according to the vunerable variable.

    }

    public void SetVunerable(bool input)
    {
        vunerable = input;
        StartCoroutine(ResetVunerable());
    }
    // public function that both sets the vunerable bool to true, and starts the timed reset.
    IEnumerator ResetVunerable()
    {
        yield return new WaitForSeconds(vunerableTime);
        SetVunerable(false);
    }
    // timed reset for the vunerable state.
    // NOTE: strange bug that is repeateable that should not be happening: the more powerups collected the less time
    // spent in the vunerable state? seems to be decently random too - possibly something to calling the coroutine
    // multiple times? something to do with a unity issue?
    // problem is that I've checked the code MULTIPLE times and this has no reason at all to happen.
}
