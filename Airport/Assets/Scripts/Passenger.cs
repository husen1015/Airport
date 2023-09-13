using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passenger : GameAgent
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        SubGoal goal1 = new SubGoal("rested", 3, false);
        SubGoal goal2 = new SubGoal("CheckedIn", 4, false);
        SubGoal goal3 = new SubGoal("PassedSecurity", 6, false);

        SubGoals.Add(goal1, 3);
        SubGoals.Add(goal2, 4);
        SubGoals.Add(goal3, 6);


        //SubGoal goal1 = new SubGoal("checkin", 3, false);
        //SubGoal goal2 = new SubGoal("passSecurity", 3, false);

        //SubGoals.Add(goal1, 3);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
