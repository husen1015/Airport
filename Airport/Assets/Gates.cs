using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates : MonoBehaviour
{
    public static Transform[] gates;
    // Start is called before the first frame update
    void Start()
    {
        gates = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            gates[i] = transform.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static Transform getGate()
    {
        return gates[0];
    }
}
