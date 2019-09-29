using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float move_speed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public bool have_spear = false;

    //Pickup_Script pickups;

    public GameObject spear, gork;


    Vector2 input;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //pickups = GetComponent<Pickup_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        // input
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        if(Input.GetKeyUp(KeyCode.R) && have_spear)
        {
            Poke();
        }
    }

    private void FixedUpdate()
    {
        if ((input.x > 0f && this.transform.localScale.x != 1) || (input.x < 0f && this.transform.localScale.x != -1))
            Flip();

        if (input != Vector2.zero)
        {
            rb.MovePosition(transform.position + new Vector3(input.x * move_speed * Time.deltaTime, input.y * move_speed * Time.deltaTime, 0f));
        }
        animator.SetBool("horizontal", input.x != 0);
        animator.SetBool("vertical", input.y > 0);
    }


    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void Poke()
    {
        //Collider2D[] collider2Ds = Physics2D.OverlapCircle(gork.transform.position, 3f);
        float dist = Vector2.Distance(transform.position, gork.transform.position);
        if (dist < 3f)
            gork.GetComponent<Gork_script>().times_hit++;
    }
}
