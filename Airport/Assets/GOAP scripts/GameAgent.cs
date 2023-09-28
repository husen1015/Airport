using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Collections;

public class SubGoal
{
    //each goal can have multiple subgoals represented by this class
    public Dictionary<string, int> SubGoals;
    public bool repeat; // signales whether or not this goal should be triggered again after its satisfies 
    public SubGoal(string goal, int priority, bool repeat) 
    {
        SubGoals= new Dictionary<string, int>();
        SubGoals.Add(goal, priority);
        this.repeat= repeat;
    }
}
public abstract class GameAgent : MonoBehaviour
{
    public List<Action> actions = new List<Action>();
    public Dictionary<SubGoal, int> SubGoals = new Dictionary<SubGoal, int>();

    Planner planner;
    Queue<Action> actionsQueue;
    public Action currAction;
    SubGoal currentGoal;
    bool prevCanSeePlayer = false;
    //FOV fov;
    protected void Start()
    {
        //fov = FOV.Instance;
        //get actions assigned in inspector 
        Action[] actionsArr = this.GetComponents<Action>();
        foreach(Action action in actionsArr)
        {
            actions.Add(action);
        }
    }
    private void Update()
    {
        //bool currentlyCanSeePlayer = fov.canSeePlayer;
        ////whenever a change in the status "can see player" occurs enforce a plan recalculation
        //if (!(currentlyCanSeePlayer ^ prevCanSeePlayer))//using xor to find when both of them agree(i.e. both true or false) to signal whether there was a change in the status
        //{
        //    return;
        //}
        //if (currentlyCanSeePlayer)
        //{
        //    GameWorld.Instance.GetWorldStates1().SetState("CanSeePlayer", 1);
        //    Debug.Log($"world states includes new state? = {GameWorld.Instance.GetWorldStates1().HasState("CanSeePlayer")}");
        //    RecalculatePlan();
        //    prevCanSeePlayer = true;
        //}
        //else if(!currentlyCanSeePlayer) 
        //{
        //    Debug.Log("removes state");
        //    GameWorld.Instance.GetWorldStates1().RemoveState("CanSeePlayer");
        //    UnityEditor.EditorApplication.isPaused = true;

        //    RecalculatePlan();
        //    prevCanSeePlayer = false;
        //}
        
        
    }

    bool invoked = false; //action invoked?
    void CompleteAction()
    {
        Debug.Log("completeing action");
        currAction.running= false;
        currAction.PostPrefom();
        invoked = false;
    }
    IEnumerator CompleteActionC(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        Debug.Log("completeing action");
        currAction.running = false;
        currAction.PostPrefom();
        invoked = false;
    }

    protected void RecalculatePlan()
    {
        planner = null;
        if (currAction != null)
        {
            currAction.running = false; //possibly this needs to be changed in the late update as well
        }
        currAction = null;

    }
    private void LateUpdate()
    {
        
        //if agent has an action
        if(currAction!= null && currAction.running)
        {
            float distanceToTarget = Vector3.Distance(currAction.target.transform.position, transform.position);
            
            if(distanceToTarget < .5f && currAction.agent.hasPath)
            {
                if (!invoked)
                {
                    currAction.ActivateAction();
                    //Invoke("CompleteAction", currAction.duration);
                    StartCoroutine(CompleteActionC((int)currAction.duration));
                    invoked = true;
                }
            }
            return;
        }

        //TODO- agent has a plan but a new better plan is currently available

        //agent has no plan, happens at the start 
        else if(planner == null || actionsQueue == null)
        {
            Debug.Log("calculating plan");
            planner = new Planner();
            //sort goals according to improtance in a descendign order
            var sortedGoals = from entry in SubGoals orderby entry.Value descending select entry;

            //UnityEditor.EditorApplication.isPaused = true;
            foreach (KeyValuePair<SubGoal, int> sortedGoal in sortedGoals)
            {
                actionsQueue = planner.plan(actions, sortedGoal.Key.SubGoals, null);
                
                if (actionsQueue != null)
                {
                    //Debug.Log("ävailable actions: ");

                    //foreach (Action a in actionsQueue)
                    //{
                    //    Debug.Log(a.Name);
                    //}

                    currentGoal = sortedGoal.Key;
                    break;
                }
            }
        }
        //completed all actions
        else if(actionsQueue != null && actionsQueue.Count == 0) 
        {
            if (!currentGoal.repeat)
            {
                SubGoals.Remove(currentGoal);
            }
            planner = null;
        }
        //completed previous action but there are still actions to do
        else if(actionsQueue != null && actionsQueue.Count> 0)
        {
            currAction = actionsQueue.Dequeue();    
            if(currAction.PrePrefom()) 
            {

                //if navmesh tag not assigned in inspector assign it with targetTag
                if(currAction.target == null && currAction.targetTag != "")
                {
                    //currAction.target = GameObject.FindWithTag(currAction.targetTag);
                    currAction.target = currAction.targetTagObj;
                }
                if(currAction.target != null)
                {
                    currAction.running= true;
                    currAction.agent.SetDestination(currAction.target.transform.position);
                }
            }
            else { actionsQueue = null; }//this will force us to get a new planner and try again
        }
    }
    
}
