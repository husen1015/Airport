using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Bench: MonoBehaviour
{
    bool seatOccupied;
    Transform restingPoint;
    // Start is called before the first frame update

    private void Start()
    {
        seatOccupied= false;
        restingPoint = transform.Find("SeatFront");
    }
    public void OccupySeat(bool occupySeat)
    {
        seatOccupied = occupySeat;
    }
    public bool IsFree()
    {
        return !seatOccupied;
    }
    public Transform getRestPoint()
    {
        return restingPoint;
    }
}
