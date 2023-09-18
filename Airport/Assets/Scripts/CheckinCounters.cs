using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckinCounters : MonoBehaviour
{
    public static CheckinCounters instance { get; private set; }
    public GameObject[] counters;
    int nextCounter = 0;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        counters = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            counters[i] = transform.GetChild(i).gameObject;
        }
    }


    public Transform GetNextAvailableCounter()
    {
        if(nextCounter >= counters.Length)
        {
            nextCounter = 0;
        }
        return counters[nextCounter++].transform.GetChild(0);

    }
}
