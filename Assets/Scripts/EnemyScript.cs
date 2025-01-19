using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    Camera cam;

    [SerializeField] GameObject followTarget;
    [SerializeField] Rigidbody2D rigidbody1;
    [SerializeField] int enemyMode; //1 - random direction once hit wall | 2 - follow player directly

    // Awake is called when the object is created
    void Awake()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyMode == 1)
        {

        }
        else if (enemyMode == 2)
        {
            Vector3 followPos = followTarget.transform.position;
            rigidbody1.SetRotation(Quaternion.LookRotation(Vector3.forward, followPos - transform.position));
        }
    }

    
}
