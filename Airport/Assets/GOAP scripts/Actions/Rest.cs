using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rest : Action
{
    Bench bench;
    public override bool PostPrefom()
    {
        Debug.Log("rested");
        bench.OccupySeat(false);
        return true;
    }

    public override bool PrePrefom()
    {
        //get a free bench and set it as its target
        bench = WaitingArea.instance.GetFreeBench(); // this may return null i.e. no available bench, so in this case assign the default resting place
        if (bench != null)
        {
            bench.OccupySeat(true);
            target = bench.getRestPoint().gameObject;
        }


        Debug.Log("resting");
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
