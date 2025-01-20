using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextControlScript : MonoBehaviour
{
    [SerializeField] GameObject followTarget;
    [SerializeField] TextMeshProUGUI display;

    // Update is called once per frame
    void Update()
    {
        display.text = "Lives: " + followTarget.GetComponent<PlayerScript>().GetLives().ToString();
    }
}
