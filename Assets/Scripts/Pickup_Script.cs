using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Script : MonoBehaviour
{
    [HideInInspector]
    public bool changable = true;
    [HideInInspector]
    public bool changed = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

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
        if (collision.gameObject.tag == "Pickups")
        {
            Debug.Log(gameObject.name + " collided with " + collision.gameObject.name);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "CraftingTable")
        {
            changable = false;

            if (this.transform.tag == "Pickups")
            {
                Debug.Log("triggered");
                collision.transform.GetComponent<Crafting_Script>().AddToTable(this.transform);

                //Crafting_Script craft = collision.transform.GetComponent<Crafting_Script>();
                //if (craft != null)
                //{
                //    craft.DoCraft(collision.transform);
                //    //Destroy(collision.gameObject, 3.5f);
                //}
            }
        }


    }

}
