using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerSpawner : MonoBehaviour
{
    public GameObject[] passengerPrefabs;
    public int spawned;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPassengers());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnPassengers()
    {
        while (spawned > 0)
        {
            int passengerIndex = Passengers.getRandomInt(0, 4);
            float spawnInterval = Random.Range(1, 3);
            yield return new WaitForSeconds(spawnInterval);

            Instantiate(passengerPrefabs[passengerIndex], transform.position, Quaternion.identity);
            Spawner.IncrementPassengerNum(1);
            spawned--;

        }
    }
}
