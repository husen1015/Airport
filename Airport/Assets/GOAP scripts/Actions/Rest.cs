using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Rest : Action
{
    NavMeshAgent agent;
    public Bench bench; //the bench object where this rest action takes place
    public int seatId = 0; //seat id which this action occupies

    public override bool PostPrefom()
    {
        GetComponent<Animator>().SetBool("Sit", false);
        GetComponent<Animator>().SetBool("Walk", true);

        //agent.enabled = true;
        //StartCoroutine(WaitSecondsEnableAgent(1)); //wait for standing up animation to finish before enabling agent again
        agent.enabled = true;

        Debug.Log("rested");
        bench.FreeSeat(seatId);
        return true;
    }

    public override bool PrePrefom()
    {

        //get a free bench and set it as its target
        bench = WaitingArea.instance.GetFreeBench(); // this may return null i.e. no available bench, so in this case assign the default resting place 
        if (bench != null)
        {
            (Transform, int) seatInfo = bench.OccupyAvailableSeat();
            target = seatInfo.Item1.gameObject;
            seatId = seatInfo.Item2;
        }

        Debug.Log("resting");
        return true;
    }

    public override void ActivateAction()
    {
        if (agent != null)
        {
            agent.enabled = false; //disable agent to remove unwanted movement
        }
        transform.position = bench.GetSeatLocation(seatId).transform.position;
        transform.rotation = Quaternion.LookRotation(-bench.transform.forward, Vector3.up);

        //transform.LookAt(bench.transform.position);

        GetComponent<Animator>().SetBool("Walk", false);
        GetComponent<Animator>().SetBool("Sit", true);

        //transform.position = bench.GetSeatLocation(seatId).transform.position + bench.transform.forward.normalized;

        //transform.rotation = bench.transform.rotation;

        //UnityEditor.EditorApplication.isPaused = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void PrePostPreform()
    {
        Debug.Log(("enabling"));
        agent.enabled = true;
    }

}
