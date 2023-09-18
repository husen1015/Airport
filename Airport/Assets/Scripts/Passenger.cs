using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passenger : GameAgent
{
    int tiredness;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        tiredness = 0;
        int tired = Passengers.getRandomInt(0, 2);
        //each passenger has 50% chance to be tired in which case it will priorotize resting above checking in
        SubGoal goal1;
        SubGoal goal2;
        if (tired == 1)
        {
            tiredness = Passengers.getRandomInt(3, 7);
            goal1 = new SubGoal("rested", 4, false);
            goal2 = new SubGoal("CheckedIn", 3, false);
            SubGoals.Add(goal1, 4);
            SubGoals.Add(goal2, 3);
        }
        else
        {
            goal1 = new SubGoal("rested", 3, false);
            goal2 = new SubGoal("CheckedIn", 4, false);
            SubGoals.Add(goal1, 3);
            SubGoals.Add(goal2, 4);
        }

        SubGoal goal3 = new SubGoal("PassedSecurity", 6, false);
        SubGoal goal4 = new SubGoal("ReadyToBoard", 8, false);



        //SubGoals.Add(goal3, 6);
        //SubGoals.Add(goal4, 8);

        //SubGoal goal1 = new SubGoal("checkin", 3, false);
        //SubGoal goal2 = new SubGoal("passSecurity", 3, false);

        //SubGoals.Add(goal1, 3);

    }


}
