using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.AI;

public abstract class Action : MonoBehaviour
{
    public string Name = "Action";
    public float cost = 1f;
    public GameObject target; //target for the navmesh
    public string targetTag;
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
            //foreach(var condition in conditions)
            //{
            //    Debug.Log($"condition = {condition.Key} with value {condition.Value}");

            //}
            if (!conditions.ContainsKey(p.Key) || conditions[p.Key] <= 0) { return false; }
            //if (conditions[p.Key] <= 0) { return false; }

        }
        return true;
    }
    //done before invoking the action
    public abstract bool PrePrefom();
    //run after done with the action
    public abstract bool PostPrefom();

    public void AddAfterEffect(WorldState ws)
    {
        afterEffects.Add(ws);
    }
    public void AddPreCondition(WorldState ws)
    {
        preConditions.Add(ws);
    }
}
