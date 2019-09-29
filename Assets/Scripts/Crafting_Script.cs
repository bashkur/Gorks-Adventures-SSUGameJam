using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting_Script : MonoBehaviour
{
    public GameObject stone, vine, wood;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddToTable(GameObject gameObject)
    {

    }

    public void DoCraft(GameObject other)
    {
        Debug.Log("i just picked up " + other.gameObject.name);
    }
}
