using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb;

    public Sprite left;
    public Sprite right;

    float mx;
    float prevMx = 1;
    bool spriteChanged = false;

    private void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");

        if (mx != prevMx && mx != 0)
        {
            if (mx == -1)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = left;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = right;
            }

            Debug.Log($"mx: {mx}");

            prevMx = mx;
        }        
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);
        rb.velocity = movement;
    }
}
