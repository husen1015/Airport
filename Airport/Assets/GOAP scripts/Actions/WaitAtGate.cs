using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitAtGate : Action
{
    public override bool PostPrefom()
    {
        GetComponent<Animator>().SetBool("Walk", true);
        Spawner.IncrementPassengerNum(-1);  
        Destroy(gameObject);
        return true;
    }

    public override bool PrePrefom()
    {
        target = Gates.getGate().gameObject;
        return true;
    }

    public override void ActivateAction()
    {
        GetComponent<Animator>().SetBool("Walk", false);
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
