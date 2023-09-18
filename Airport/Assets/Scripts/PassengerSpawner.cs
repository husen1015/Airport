using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerSpawner : MonoBehaviour
{
    public GameObject passengerPrefab;
    int spawned = 10;
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
            float spawnInterval = Random.Range(2, 5);
            yield return new WaitForSeconds(spawnInterval);

            Instantiate(passengerPrefab, transform.position, Quaternion.identity);
            spawned--;

        }
    }
}
