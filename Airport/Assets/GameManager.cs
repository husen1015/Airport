using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //set 3 available counters for check in
        GameWorld.Instance.GetWorldStates1().SetState("AvailableCounters", 3);
        //foreach(var s in GameWorld.Instance.GetWorldStates())
        //{
        //    Debug.Log($"state: {s.Key}");
        //}
    }


}
