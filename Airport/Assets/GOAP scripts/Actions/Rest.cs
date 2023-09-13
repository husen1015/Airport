using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rest : Action
{
    public override bool PostPrefom()
    {
        Debug.Log("rested");

        return true;
    }

    public override bool PrePrefom()
    {
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
