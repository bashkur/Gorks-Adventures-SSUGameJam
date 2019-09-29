using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Script : MonoBehaviour
{
    [HideInInspector]
    public bool changable = true;
    [HideInInspector]
    public bool changed = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.gameObject.tag != "Player" && collision.gameObject.tag == "Map")
        {
            transform.position = transform.position + new Vector3(1, 1, 0);
        }
        if (this.gameObject.tag != "Player" && collision.gameObject.tag == "Bug")
        {
            changed = true;
        }
        if (this.gameObject.tag != "Player" && collision.gameObject.tag == "Material")
        {
            Debug.Log(gameObject.name + " collided with " + collision.gameObject.name);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "CraftingTable")
        {
            changable = false;
            collision.transform.GetComponent<Crafting_Script>().AddToTable(this.transform);
        }


    }

}
