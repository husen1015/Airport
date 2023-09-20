using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCounter : MonoBehaviour
{
    int queueLimit = 5;
    int currQueue = 0;
    Transform queue;
    public Transform[] queueTransforms;
    public Queue<SecurityCheck> queueOccupants;
    void Start()
    {
        queue = transform.Find("Queue-1");
        queueTransforms = new Transform[queue.childCount];
        queueOccupants = new Queue<SecurityCheck>();
        for (int i = 0; i < queueTransforms.Length; i++)
        {
            queueTransforms[i] = queue.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool isQueueAvailable() { return currQueue < queueLimit; }
    
    //returns place in line and its index
    public (Transform, int, int) admitNewPassenger(SecurityCheck sc)
    {
        queueOccupants.Enqueue(sc);
        currQueue++;
        return (queueTransforms[currQueue-1], currQueue-1, currQueue*5);
    }
    public void AdvanceQueue()
    {
        if(currQueue > 0)
        {
            queueOccupants.Dequeue();
            int i = 0;
            foreach (SecurityCheck sc in queueOccupants)
            {
                
                //sc.placeInLine--;
                sc.target = queueTransforms[i].gameObject;

                i++;
            }
            currQueue--;
        }


    }
}
