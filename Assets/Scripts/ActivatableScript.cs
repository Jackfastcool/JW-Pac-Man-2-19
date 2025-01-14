using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatableScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate(int mode) //mode determins the behavior of the activatable object
    {
        if (mode == 0) //door - game object is set to inactive due to error spam
        {
            gameObject.SetActive(false);
        }
    }
}
