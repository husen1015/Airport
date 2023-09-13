using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameWorld.Instance.GetWorldStates1().SetState("AvailableCounters", 1);
        foreach(var s in GameWorld.Instance.GetWorldStates())
        {
            Debug.Log($"state: {s.Key}");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
