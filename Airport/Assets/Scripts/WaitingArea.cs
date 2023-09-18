using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingArea : MonoBehaviour
{
    public static WaitingArea instance { get; private set; }

    public Bench[] benches;
    

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
        benches = GetComponentsInChildren<Bench>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Bench GetFreeBench()
    {
        foreach (Bench b in benches)
        {
            if (b.HasFreeSeat())
            {
                return b;
            }
        }
        return null;
    }
}
