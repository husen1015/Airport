using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitAtGate : Action
{
    public override bool PostPrefom()
    {
        Destroy(gameObject);
        return true;
    }

    public override bool PrePrefom()
    {
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
