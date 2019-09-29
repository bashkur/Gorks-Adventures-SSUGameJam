using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting_Script : MonoBehaviour
{
    public GameObject stone, vine, wood, spear, player;
    public Sprite[] sprites;

    private int stone_count, vine_count, wood_count;

    // Start is called before the first frame update
    void Start()
    {
        stone_count = 0;
        vine_count = 0;
        wood_count = 0;
    }

    private void Update()
    {
        if (stone_count > 0 && vine_count > 0 && wood_count > 0)
            DoCraft();
    }

    public void AddToTable(Transform other)
    {
        Debug.Log(other.name + " was added to table");
        other.transform.parent = this.transform;

        if (other.name == "Stone(Clone)")
        {
            stone_count++;
            Debug.Log("Stone count: " + stone_count);
        }
        if (other.name == "Vines(Clone)")
        {
            vine_count++;
            Debug.Log("Vine count: " + vine_count);
        }
        if (other.name == "Wood(Clone)")
        {
            wood_count++;
            Debug.Log("Wood count: " + wood_count);
        }
    }

    // check if any mat has been changed
    // if yes, then instantiate a random item
    // otherwise, make a spear
    public void DoCraft()
    {
        bool make_random = false;
        foreach (Transform child in this.transform)
        {
            if(child.hasChanged)
                make_random = true;
        }

        if (make_random)
        {
            int unlucky_num = Random.Range(1, sprites.Length);
            Debug.Log("crafting  random... unlucky number is " + unlucky_num);
            GameObject trash = new GameObject("Trash", typeof(SpriteRenderer));
            trash.GetComponent<SpriteRenderer>().sprite = sprites[unlucky_num];
            trash.GetComponent<SpriteRenderer>().sortingOrder = 2;
            trash.transform.position = new Vector2(0, 0);

        }
        else
        {
            Debug.Log("crafting spear...");
            Instantiate(spear, new Vector2(0, 0), Quaternion.identity);
            spear.transform.parent = player.transform;
            spear.transform.position = player.transform.forward;
            player.GetComponent<PlayerMovement>().have_spear = true;
        }

        foreach (Transform child in this.transform)
        {
            Debug.Log("destroying " + child.name);
            Destroy(child.gameObject);
        }

        stone_count = 0;
        vine_count = 0;
        wood_count = 0;
    }
}
