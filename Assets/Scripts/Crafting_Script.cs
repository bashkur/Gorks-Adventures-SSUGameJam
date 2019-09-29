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

    // Update is called once per frame
    void Update()
    {

    }

    public void AddToTable(Transform other)
    {
        Debug.Log(other.name + " was added to table");
        other.transform.parent = this.transform;

        if (stone_count > 0 && vine_count > 0 && wood_count > 0)
            DoCraft();

        if (other.name == "Stone")
        {
            stone_count++;
            Debug.Log("Stone count: " + stone_count);
        }
        if (other.name == "Vine")
        {
            vine_count++;
            Debug.Log("Vine count: " + stone_count);

        }
        if (other.name == "Wood")
        {
            wood_count++;
            Debug.Log("Wood count: " + stone_count);

        }



    }

    public void DoCraft()
    {
        Debug.Log("crafring...");
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
