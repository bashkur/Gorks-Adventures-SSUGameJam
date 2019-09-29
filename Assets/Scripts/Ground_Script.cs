using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Script : MonoBehaviour
{
    List<GameObject> pickupList = new List<GameObject>();
    public GameObject rockpre;
    public GameObject woodpre;
    public GameObject vinepre;

    void Start()
    {
        System.Random rand = new System.Random();
        for(int i = 0; i < 2; i++)
        {
            pickupList.Add(Instantiate(rockpre,new Vector2(rand.Next(40) - 20, rand.Next(40) - 25), Quaternion.identity));
            pickupList.Add(Instantiate(woodpre, new Vector2(rand.Next(40) - 20, rand.Next(40) - 25), Quaternion.identity));
            pickupList.Add(Instantiate(vinepre, new Vector2(rand.Next(40) - 20, rand.Next(40) - 25), Quaternion.identity));
        }
    }
}
