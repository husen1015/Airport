using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Action : MonoBehaviour
{
    public string Name = "Action";
    public float cost = 1f;
    public GameObject target; //target for the navmesh
    public string targetTag;
    public GameObject targetTagObj;
    public float duration = 0; //time needed to complete
    public List<WorldState> preConditions;
    public List<WorldState> afterEffects;
    public NavMeshAgent agent;

    public Dictionary<string, int> pre_conditions;
    public Dictionary<string, int> after_effects;

    public WorldStates agentBeleifs; //internal states

    public bool running = false; //is the action currently running?

    public Action()
    {
        pre_conditions= new Dictionary<string, int>();
        after_effects= new Dictionary<string, int>();
    }

    private void Awake()
    {

        agent = GetComponent<NavMeshAgent>();

        //populate world states
        if(preConditions!=null)
        {
            foreach(WorldState worldState in preConditions)
            {
                pre_conditions.Add(worldState.key, worldState.value);
            }
        }
        if (afterEffects != null)
        {
            foreach (WorldState worldState in afterEffects)
            {
                after_effects.Add(worldState.key, worldState.value);
            }
        }
        //init the target tag object here instead in gameAgent to reduce the number of times FindWithTag is being called for
        if (targetTag != "")
        {

            //targetTagObj = GameObject.FindWithTag(targetTag);
        }

    }
    private void Start()
    {

    }

    //currently assuming all actions are achievable. might change later
    public bool IsAcheivable()
    {
        return true;
    }
    //this method determines whether the action is achievable given a set of conditions
    public bool IsAchievableGiven(Dictionary<string, int> conditions)
    {
        //make sure all required conditions are found in pre_conditions
        foreach (KeyValuePair<string, int> p in pre_conditions)
        {
            //Debug.Log("checking action is achievable given? action name:");
            //Debug.Log(this.target);
            //foreach (var condition in conditions)
            //{
            //    Debug.Log($"condition = {condition.Key} with value {condition.Value}");

            //}
            //Debug.Log("pre conditions");
            //foreach (var condition in pre_conditions)
            //{
            //    Debug.Log($"condition = {condition.Key} with value {condition.Value}");

            //}

            if (!conditions.ContainsKey(p.Key) || conditions[p.Key] <= 0) { return false; }
            //UnityEditor.EditorApplication.isPaused = true;
        }
        return true;
    }
    //done before invoking the action
    public abstract bool PrePrefom();
    //run after done with the action
    public abstract bool PostPrefom();

    //this method runs whenever the game agent reached its destination and spends x time in it (for example resting/talking/...)
    public abstract void ActivateAction();
    //this method runs whenever the game agent reached its destination and spends x time in it (for example resting/talking/...)

    //this method runs 1 second before the post preform, useful for animation transitions
    public virtual void PrePostPreform()
    {

    }

    public void AddAfterEffect(WorldState ws)
    {
        afterEffects.Add(ws);
    }
    public void AddPreCondition(WorldState ws)
    {
        pre_conditions.Add(ws.key, ws.value);
    }


}
