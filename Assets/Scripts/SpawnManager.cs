using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] childPrefabs;
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

    // SPAWN PREFABS
    void SpawnRandomPrefabs(GameObject[] prefabsList)
    {
        int prefabIndex = Random.Range(0, prefabsList.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        Instantiate(prefabsList[prefabIndex], spawnPos, prefabsList[prefabIndex].transform.rotation);
    }

    // SPAWNS POWERUP PREFABS
    public void SpawnPowerUps(){
        SpawnRandomPrefabs(powerupPrefabs);
    }

    // SPAWNS CHILDREN PREFABS
    public void SpawnAnimals(){
        SpawnRandomPrefabs(childPrefabs);
    }

    // STOPS SPAWNING ONCE GAME ENDS
    public void StopSpawning(){
        CancelInvoke();
        DestroyAllSpawns();
    }

    public void DestroyAllSpawns()
    {
        GameObject[] childPrefabArray = GameObject.FindGameObjectsWithTag("Child");
        //GameObject[] powerUpArray = GameObject.FindObjectsOfType<powerupPrefabs>();

        for (int i = 0; i < childPrefabArray.Length; i++)
        {
            Destroy(childPrefabArray[i]);
        }
       // for (int i = 0; i < powerUpArray.Length; i++)
        //{
          //  Destroy(powerUpArray[i]);
        //}
    }

    // STARTS SPAWNING ONCE GAME STARTS
    public void StartSpawning(){
        InvokeRepeating("SpawnAnimals", startDelay, spawnInterval);
        InvokeRepeating("SpawnPowerUps", 6, spawnInterval);
    }
}
