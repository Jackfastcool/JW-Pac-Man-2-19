using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{

    int accumulator;
    int toggle;

    SpriteRenderer spriteRenderer;

    [SerializeField] Collider2D collider1;

    // Awake is called when the object is created
    void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        StartCoroutine(blink());
    }

    // Update is called once per frame
    void Update()
    {
        if (collider1.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            GameObject.Destroy(this.gameObject, 0.0001f);
            // NOTE: there is a time delay (close to one frame) on the destroy because of unity's update orders.
        }
    }

    IEnumerator blink()
    {
        while (true)
        {
            accumulator += 1;
            toggle = accumulator % 2;
            // after this toggle ends up switching between 1 and zero every time this exccecutes.
            if (toggle == 1)
            {
                spriteRenderer.color = Color.clear;
            }
            else
            {
                spriteRenderer.color = Color.HSVToRGB(0.13f, 0.5f, 1);
            }
            yield return new WaitForSeconds(0.3f);
        }
    }
}
