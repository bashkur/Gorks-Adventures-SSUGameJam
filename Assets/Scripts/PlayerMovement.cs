using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float move_speed = 5f;
    public Rigidbody2D rb;
    public Animator animator;

    Vector2 input;
    Vector3 h, v;
    bool facing_right = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // input
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        if (input.x != 0)
        {
            transform.Translate(new Vector3(input.x * move_speed * Time.deltaTime, 0f, 0f));

            if (input.x > 0 && !facing_right)
            {
                Flip();
                //facing_right = true;
            }
            else if (input.x < 0 && facing_right)
            {
                Flip();
                //facing_right = false;
            }
        }
        if (input.y != 0)
        {
            transform.Translate(new Vector3(0f, input.y * move_speed * Time.deltaTime, 0f));
        }

        animator.SetFloat("horizontal", input.x);
        animator.SetFloat("vertical", input.y);
    }

    void Flip()
    {
        facing_right = !facing_right;
        Vector3 player_scale = transform.localScale;
        player_scale.x *= -1;
        transform.localScale = player_scale;
    }
}
