using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class SecurityArea : MonoBehaviour
{
    public static SecurityArea instance { get; private set; }

    public SecurityCounter[] securityCounters;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        securityCounters = GetComponentsInChildren<SecurityCounter>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public SecurityCounter GetFreeCounter()
    {
        foreach (SecurityCounter sc in securityCounters)
        {
            if (sc.isQueueAvailable())
            {
                return sc;
            }
        }
        return null;
    }
}
