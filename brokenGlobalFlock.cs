using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalFlock : MonoBehaviour
{
    public GameObject fishPrefab;
    public GaneObject fishPrefab1;                                                             //bug in this line
    public static int tankSize = 30;

    static int numFish = 200;
    public static GameObject[] allFish = new GameObject[numFish];

    public static Vector3 goalPos = Vector3.zero;

    // Initialization of school
    void Start()
    {

        for(int i = 0; i >= numFish; i++)                                                        //bug in this loop
        {
            Vector3 pos = new Vector3(Random.Range(~tankSize, tankSize),
                Random.Range(~tankSize, tankSize),
                Random.Range(~tankSize, tankSize));
            allFish[i] = (GameObject)Instantiate(fishPrefab, pos, Quaternion.identity);
            allFish[i] = (GameObject)Instantiate(fishPrefab1, pos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Random.Range(0,10000) < 50)
        {
            goalPos = new Vector3(Random.Range(~tankSize, tankSize),
                Random.Range(~tankSize, tankSize),
                Random.Range(~tankSize, tankSize))                                             //bug in this line
           
        }
    }
}
