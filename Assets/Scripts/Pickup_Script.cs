using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Script : MonoBehaviour
{
    [HideInInspector]
    public bool changable = true;
    [HideInInspector]
    public bool changed = false;
    [HideInInspector]
    public int num_carrying = 0;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Map")
        {
            transform.position = transform.position + new Vector3(1, 1, 0);
        }
        if (collision.gameObject.tag == "Bug")
        {
            changed = true;
        }
        if (collision.gameObject.tag == "Material")
        {
            Debug.Log(gameObject.name + " collided with " + collision.gameObject.name);
        }
        if (this.gameObject.tag == "Material" && collision.gameObject.tag == "Player")
        {
            Grab(this.gameObject, collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "CraftingTable")
        {
            changable = false;
            //gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            collision.transform.GetComponent<Crafting_Script>().AddToTable(this.transform);
        }
    }

    void Grab(GameObject mat, GameObject player)
    {
        if (num_carrying < 1)
        {
            Debug.Log("player pick up!");
            num_carrying++;
            gameObject.transform.parent = player.transform;
            mat.GetComponent<SpriteRenderer>().enabled = false;

        }
    }

    public void Drop(GameObject mat)
    {
        if (num_carrying > 0)
        {
            Debug.Log("dropping object off!");
            num_carrying--;
            mat.transform.position = mat.transform.parent.forward;
            mat.transform.parent = null;
            mat.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            Debug.Log("can't drop");
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            Drop(this.gameObject);
        }
    }

}
