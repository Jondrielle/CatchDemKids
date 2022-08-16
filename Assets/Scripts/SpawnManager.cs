using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public GameObject[] powerupPrefabs;
    public float spawnRangeX = 20;
    public float spawnPosZ = 20;
    public float startDelay = 2f;
    public float spawnInterval = 1.5f;
    public float spawnIntervalMax = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartSpawning();
    }

    void SpawnRandomPrefabs(GameObject[] prefabsList)
    {
        int prefabIndex = Random.Range(0, prefabsList.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        Instantiate(prefabsList[prefabIndex], spawnPos, prefabsList[prefabIndex].transform.rotation);
    }

    public void SpawnPowerUps(){
        SpawnRandomPrefabs(powerupPrefabs);
    }

    public void SpawnAnimals(){
        SpawnRandomPrefabs(animalPrefabs);
    }

    public void StopSpawning(){
        CancelInvoke();
    }

    public void StartSpawning(){
        InvokeRepeating("SpawnAnimals", startDelay, spawnInterval);
        InvokeRepeating("SpawnPowerUps", startDelay, spawnIntervalMax);
    }
}
