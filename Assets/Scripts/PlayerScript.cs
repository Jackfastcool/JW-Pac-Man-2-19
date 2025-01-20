using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody1;
    [SerializeField] float velocity;
    [SerializeField] Collider2D collider1;
    [SerializeField] int lives;

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
            //print("collectible detected");
            enemyList = GameObject.FindGameObjectsWithTag("Enemy");
            //print(enemyList);
            foreach (GameObject enemy in enemyList)
            {
                enemy.GetComponent<EnemyScript>().SetVunerable(true);

            }
        }
        // if the player has picked up a power pill then it goes through every single enemy and sets the vunerable
        // state to true. NOTE: this does this for EVERY enemy, including ones in other rooms.

        if (lives <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        // resets the current scene if the player runs out of lives.
    }

    Vector2 moveVal;
    void OnMove(InputValue val) //gets value from input and sticks it in a vec2 variable
    {
        moveVal = val.Get<Vector2>();
    }

    public void Death()
    {
        lives -= 1;
        gameObject.transform.position = new Vector2(-0.5f, 0);
        GameObject.FindGameObjectWithTag("CameraController").GetComponent<CameraControlScript>().SetCameraLocation(0, 0);
    }
    // takes away one life and resets the position of the player to take them out of danger.
    // resets the CameraController position to the first room.

    public int GetLives()
    {
        return lives;
    }
    // returns lives variable for UI components.
}
