using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
   
    public GameObject[] planePrefabs;
    public GameObject[] cloudPrefabs;
    public GameObject[] middleCloudPrefabs;
    public GameObject[] lowerCloudPrefabs;
    private float spawnRangeX = 15;
    private float spawnPosZ = 20;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    private GameManager gameManager;

    void SpawnRandomPlane()
    {
        if (gameManager.gameOver == false)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            int planeIndex = Random.Range(0, planePrefabs.Length);
            Instantiate(planePrefabs[planeIndex], spawnPos, planePrefabs[planeIndex].transform.rotation);
        }
    }

    void SpawnRandomCloud()
    {
        
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            int cloudIndex = Random.Range(0, cloudPrefabs.Length);
            Instantiate(cloudPrefabs[cloudIndex], spawnPos, cloudPrefabs[cloudIndex].transform.rotation);
        
    }

    void SpawnRandomMiddleCloud()
    {
        
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), -10, spawnPosZ);
            int middleCloudIndex = Random.Range(0, lowerCloudPrefabs.Length);
            Instantiate(middleCloudPrefabs[middleCloudIndex], spawnPos, middleCloudPrefabs[middleCloudIndex].transform.rotation);
        
    }
    void SpawnRandomLowerCloud()
    {
       
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), -20, spawnPosZ);
            int lowerCloudIndex = Random.Range(0, lowerCloudPrefabs.Length);
            Instantiate(lowerCloudPrefabs[lowerCloudIndex], spawnPos, lowerCloudPrefabs[lowerCloudIndex].transform.rotation);
        
    }

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        InvokeRepeating("SpawnRandomPlane", startDelay, spawnInterval);
        InvokeRepeating("SpawnRandomCloud", startDelay, spawnInterval);
        InvokeRepeating("SpawnRandomLowerCloud", startDelay, spawnInterval);
        InvokeRepeating("SpawnRandomMiddleCloud", startDelay, spawnInterval);
    }

}
