using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //public static Spawner Instance;

    public int spawned;
    public PassengerSpawner passengerSpawner1;
    public PassengerSpawner passengerSpawner2;
    public PassengerSpawner passengerSpawner3;
    static int currentlySpawned = 0;
    public TextMeshProUGUI currentlySpawnedTxt;
    private void Awake()
    {
        //if (Instance == null)
        //{
        //    Instance = this;
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
        spawned = (int)Controller.numberOfPassengers;
        passengerSpawner1.spawned = spawned / 3;
        passengerSpawner2.spawned = spawned / 3;
        passengerSpawner3.spawned = spawned / 3;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentlySpawnedTxt.text = $"Active passengers in scene: {currentlySpawned}";
    }
    public static void IncrementPassengerNum(int amount)
    {
        currentlySpawned += amount;
    }

}
