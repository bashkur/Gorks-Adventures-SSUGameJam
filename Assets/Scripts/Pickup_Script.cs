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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CraftingTable")
        {
            changable = false;
        }
    }

}
