using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passengers : MonoBehaviour
{
    static System.Random random;
    // Start is called before the first frame update
    private void Awake()
    {
        
        random = new System.Random();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static int getRandomInt(int minBound, int maxBound)
    {
        return random.Next(minBound, maxBound);
    }
}
