using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting_Script : MonoBehaviour
{
    public GameObject stone, vine, wood;

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

    public void DoCraft()
    {
        Debug.Log("crafting...");
        foreach(Transform child in this.transform)
        {
            Debug.Log("destroying " + child.name);
            Destroy(child.gameObject, 2f);
        }
        stone_count = 0;
        vine_count = 0;
        wood_count = 0;
    }
}
