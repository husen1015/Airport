using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Passenger : GameAgent
{
    int tiredness;
    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        SubGoal goal1;
        SubGoal goal2;

        //each passenger has 50% chance to be tired in which case it will priorotize resting above checking in
        int tired = Passengers.getRandomInt(0, 2);

        Debug.Log(tired);
        if (tired == 1)
        {
            Debug.Log("here");
            tiredness = Passengers.getRandomInt(3, 7);
            WorldState rested = new WorldState("Rested", 1);
            GetComponent<CheckIn>().AddPreCondition(rested);
            goal1 = new SubGoal("Rested", 4, false);
            goal2 = new SubGoal("CheckedIn", 3, false);
            SubGoals.Add(goal1, 4);
            SubGoals.Add(goal2, 3);
            RecalculatePlan();
        }
        else
        {
            goal1 = new SubGoal("Rested", 3, false);
            goal2 = new SubGoal("CheckedIn", 4, false);
            SubGoals.Add(goal1, 3);
            SubGoals.Add(goal2, 4);
        }
        tiredness = 0;
        
        SubGoal goal3 = new SubGoal("PassedSecurity", 6, false);
        SubGoal goal4 = new SubGoal("ReadyToBoard", 8, false);

        SubGoals.Add(goal3, 6);
        SubGoals.Add(goal4, 8);



    }

    private void Update()
    {

    }

}
