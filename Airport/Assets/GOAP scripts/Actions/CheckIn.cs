using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIn : Action
{
    public override bool PostPrefom()
    {

        //add 1 to available counters
        var ws = GameWorld.Instance.GetWorldStates1().GetStates();
        int availableCounters = ws["AvailableCounters"];
        GameWorld.Instance.GetWorldStates1().SetState("AvailableCounters", availableCounters + 1);
        
        return true;
    }

    public override bool PrePrefom()
    {
        //go to an empty check in counter
        target = CheckinCounters.instance.GetNextAvailableCounter().gameObject;

        //remove one from available counters
        Debug.Log($"checking in, curr available counters: {GameWorld.Instance.GetWorldStates1().GetStates()["AvailableCounters"]}");
        var ws = GameWorld.Instance.GetWorldStates1().GetStates();
        int availableCounters = ws["AvailableCounters"];
        GameWorld.Instance.GetWorldStates1().SetState("AvailableCounters", availableCounters - 1);
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
