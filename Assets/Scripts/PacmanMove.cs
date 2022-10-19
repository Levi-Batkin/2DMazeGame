using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMove : MonoBehaviour
{
    public float speed = 0.4f;
    Rigidbody2D rb;
    private Animator anim;

    IEnumerator StartMove()
    {
        Vector2 velocity = rb.velocity;
        yield return new WaitForSeconds(4);
        velocity.x = 5f; 
        velocity.y = 0;
        rb.velocity = velocity;
    }
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        StartCoroutine(StartMove());
    }
    void FixedUpdate() {
    // Move closer to Destination
        Vector2 velocity = rb.velocity;
        if (PlayerPrefs.GetFloat("allowedmove") == 1f) {
            if (Input.GetKey("a") || Input.GetKey("left"))
            {
                velocity.x = -5f;
                velocity.y = 0;
                anim.Play("Left");
            }

            else if (Input.GetKey("d") || Input.GetKey("right"))
            {
                velocity.x = 5f; 
                velocity.y = 0;
                anim.Play("Right");
            }
            else if (Input.GetKey("w") || Input.GetKey("up"))
            {
                velocity.y = 5f;
                velocity.x = 0;
                anim.Play("Up");
            }
            else if (Input.GetKey("s") || Input.GetKey("down"))
            {
                velocity.y = -5f;
                velocity.x = 0;
                anim.Play("Down");
            }
            rb.velocity = velocity;
        }
        else
        {
            Vector2 velocity2 = rb.velocity;
            velocity2.x = 0f; 
            velocity2.y = 0f;
            rb.velocity = velocity2;
        }
    }

}
