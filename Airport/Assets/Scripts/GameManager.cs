using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        GameWorld.Instance.GetWorldStates1().SetState("AvailableCounters", 28);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        //set 3 available counters for check in
        //foreach(var s in GameWorld.Instance.GetWorldStates())
        //{
        //    Debug.Log($"state: {s.Key}");
        //}
    }


}
