using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20;
    private float spawnPosZ = 20;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomAnimal()
    {
        int animalIdx1 = Random.Range(0, animalPrefabs.Length);
        // int animalIdx2 = Random.Range(0, animalPrefabs.Length);
        // int animalIdx3 = Random.Range(0, animalPrefabs.Length);

        Vector3 spawnFromTopPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        // Vector3 spawnFromLeftPos = new Vector3(-spawnRangeX, 0, Random.Range(0, spawnPosZ));
        // Vector3 spawnFromRightPos = new Vector3(spawnRangeX, 0, Random.Range(0, spawnPosZ));

        Instantiate(animalPrefabs[animalIdx1], spawnFromTopPos, animalPrefabs[animalIdx1].transform.rotation);
        // Instantiate(animalPrefabs[animalIdx2], spawnFromLeftPos, Quaternion.Euler(0f, 90f, 0f));
        // Instantiate(animalPrefabs[animalIdx3], spawnFromRightPos, Quaternion.Euler(0f, 270f, 0f));
    }
}

