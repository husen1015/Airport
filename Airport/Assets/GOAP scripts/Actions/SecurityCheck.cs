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
        postPreformed= true;
        sc.AdvanceQueue();
        Debug.Log("post security");
        return true;
    }

    public override bool PrePrefom()
    {
        var lineInfo = sc.admitNewPassenger(this);
        target = lineInfo.Item1.gameObject;
        placeInLine = lineInfo.Item2;
        duration = lineInfo.Item3;
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!postPreformed)
        {
            agent.SetDestination(target.transform.position);
        }
    }
}
