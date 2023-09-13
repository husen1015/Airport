using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerSpawner : MonoBehaviour
{
    public GameObject passengerPrefab;
    bool spawned = false;
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
        while (!spawned)
        {
            spawned= true;
            float spawnInterval = Random.Range(3, 4);
            yield return new WaitForSeconds(spawnInterval);

            Instantiate(passengerPrefab, transform.position, Quaternion.identity);
        }
    }
}
