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
        int i = 0;
        target = matList[i];

        while ((target.transform.GetComponent<Pickup_Script>().changed || !target.transform.GetComponent<Pickup_Script>().changable) && i < matList.Length )
        {
            target = matList[i++];
        }
        if (i >= matList.Length)
        {
            target = GameObject.FindGameObjectWithTag("Player");
            StartCoroutine(ChasePlayer());
        }
        else
        {
            StartCoroutine(MoveToTarget());
        }
    }

    IEnumerator ChasePlayer()
    {
        Vector2 startpos = transform.position;
        for (float inc = 0;inc >= 1; inc += .001f)
        {

            transform.position = Vector2.Lerp(startpos, target.transform.position, inc);
            yield return null;

        }

        print("gotcha");
    }

    IEnumerator MoveToTarget()
    {
        Vector2 startpos = transform.position;
        for (float inc= 0; !target.transform.GetComponent<Pickup_Script>().changed; inc += .001f )
        {

            transform.position = Vector2.Lerp(startpos, target.transform.position, inc);
            yield return null;

        }
        yield return new WaitForSeconds(5);
        findMat();
    }
}
