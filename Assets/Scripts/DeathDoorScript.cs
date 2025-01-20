using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathDoorScript : MonoBehaviour
{

    [SerializeField] GameObject activeRoom;
    // I did originally have plans to get all of the children in the activeRoom, but after some research I found
    // that the solution will be very complex.

    bool activeEnemies;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        activeEnemies = false;
        if (!(activeRoom.GetComponentInChildren<EnemyScript>() == null))
        {
            activeEnemies = true;
        }
        if (!activeEnemies)
        {
            gameObject.SetActive(false);
        }
        // the above code checks all children in the activeRoom, and if it cannot find an EnemyScript, it will
        // set itself to inactive.
    }
}
