using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckinCounters : MonoBehaviour
{
    public static GameObject[] counters;
    static int nextCounter = 1;
    // Start is called before the first frame update
    void Start()
    {
        counters = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            counters[i] = transform.GetChild(i).gameObject;
        }
    }


    public static GameObject GetNextAvailableCounter()
    {
        if(nextCounter >= counters.Length)
        {
            nextCounter = 0;
        }
        return counters[nextCounter++];

    }
}
