using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManadger : MonoBehaviour
{
    public GameObject EnemyCar;
    public GameObject spawnZone;
    private float spawnRangeX = 20;
    private float startDelay = 2;
    private float spawnInterval = 30f;
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, spawnInterval);
    }

    // Update is called once per frame
  
    void SpawnEnemy()
    {
        Vector3 spawnPos = new Vector3(Random.Range(spawnZone.transform.position.x - spawnRangeX, spawnZone.transform.position.x+spawnRangeX), 0-13.5f, spawnZone.transform.position.z);
        Instantiate(EnemyCar, spawnPos, EnemyCar.transform.rotation);
        spawnPos = new Vector3(Random.Range(spawnZone.transform.position.x - spawnRangeX, spawnZone.transform.position.x + spawnRangeX), 0, spawnZone.transform.position.z);
        Instantiate(EnemyCar, spawnPos, EnemyCar.transform.rotation);
    }
}