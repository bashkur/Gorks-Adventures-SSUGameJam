using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gork_script : MonoBehaviour
{
    GameObject target;
    int timesThrough = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null && timesThrough >5)
        {
            findMat();
        }
        timesThrough++;
    }

    void findMat()
    {
        GameObject[] matList = GameObject.FindGameObjectsWithTag("Material");

        target = matList[Random.Range(0, matList.Length - 1)];

        while (target.transform.GetComponent<Pickup_Script>().changed || !target.transform.GetComponent<Pickup_Script>().changable )
        {
            target = matList[Random.Range(0, matList.Length - 1)];
        }

        StartCoroutine(MoveToTarget());
    }

    IEnumerator MoveToTarget()
    {
        print(target);
        for (; !target.transform.GetComponent<Pickup_Script>().changed;)
        {

            transform.position = Vector2.Lerp(transform.position, target.transform.position, .005f);
            yield return null;

        }
        findMat();
    }
}
