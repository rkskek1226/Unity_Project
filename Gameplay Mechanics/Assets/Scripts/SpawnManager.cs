using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public GameObject[] powerupPrefab;
    public GameObject bossPrefab;
    public GameObject minionPrefab;
    private float spawnRange = 9;
    private float spawnPosX;
    private float spawnPosZ;

    public int enemyCount;
    private int waveNumber = 1;
    private int bossWave = 1;
    private int minionMaxCnt = 4;

    // Start is called before the first frame update
    void Start()
    {
        int randomIdx = Random.Range(0, powerupPrefab.Length);

        if (waveNumber == bossWave)
            SpawnBossWave();
        else
            SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab[randomIdx], GenerateSpawnPosition(), powerupPrefab[randomIdx].transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0)
        {
            int randomIdx = Random.Range(0, powerupPrefab.Length);
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab[randomIdx], GenerateSpawnPosition(), powerupPrefab[randomIdx].transform.rotation);
        }
    }

    private void SpawnBossWave()
    {
        int randomIdx = Random.Range(0, minionMaxCnt);
        for (int i = 0; i < randomIdx; i++)
            Instantiate(minionPrefab, GenerateSpawnPosition(), minionPrefab.transform.rotation);
        Instantiate(bossPrefab, GenerateSpawnPosition(), bossPrefab.transform.rotation);
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int randomIdx = Random.Range(0, enemyPrefab.Length);
            Instantiate(enemyPrefab[randomIdx], GenerateSpawnPosition(), enemyPrefab[randomIdx].transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        spawnPosX = Random.Range(-spawnRange, spawnRange);
        spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}
