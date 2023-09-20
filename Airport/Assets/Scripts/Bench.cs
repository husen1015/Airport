using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bench : MonoBehaviour
{
    bool[] seatStats;
    Transform[] seats;

    private void Start()
    {
        seatStats = new bool[3] { true, true, true }; // each bench has 3 seats and they all start free
        seats = new Transform[3]; 
        Transform seatsParent = transform.Find("Seat");
        if(seatsParent == null)
        {
            Debug.Log(this);
        }
        seats[0] = seatsParent.GetChild(0);
        seats[1] = seatsParent.GetChild(1);
        seats[2] = seatsParent.GetChild(2);
    }


    public bool HasFreeSeat()
    {
        return seatStats[0] || seatStats[1] || seatStats[2];
    }

    public (Transform, int) OccupyAvailableSeat()
    {
        int i = 0;
        for (; i < 3; i++)
        {
            if (seatStats[i])
            {
                seatStats[i] = false;
                break;
            }
        }
        return (seats[i], i);
    }
    public void FreeSeat(int seatId)
    {
        seatStats[seatId] = true;
    }
    public Transform GetSeatLocation(int seatId)
    {
        return seats[seatId];
    }
}
