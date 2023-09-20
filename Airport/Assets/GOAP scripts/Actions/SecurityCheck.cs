using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class SecurityCheck : Action
{
    public SecurityCounter sc;
    public int placeInLine;
    bool postPreformed = false;

    public override bool PostPrefom()
    {
        GetComponent<Animator>().SetBool("Walk", true);
        postPreformed = true;
        sc.AdvanceQueue();
        Debug.Log("post security");
        return true;
    }

    public override bool PrePrefom()
    {
        //get a security counter and set it as its target
        sc = SecurityArea.instance.GetFreeCounter(); // this may return null i.e. no available counter, so in this case assign the default transform. TODO: change this so that passenger rests until a place is free
        var lineInfo = sc.admitNewPassenger(this);
        target = lineInfo.Item1.gameObject;
        placeInLine = lineInfo.Item2;
        duration = lineInfo.Item3;
        return true;
    }

    public override void ActivateAction()
    {
        transform.LookAt(sc.transform.position);
        GetComponent<Animator>().SetBool("Walk", false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target!=null && !postPreformed)
        {
            agent.SetDestination(target.transform.position);
            transform.LookAt(sc.transform.position);

        }
    }
}
