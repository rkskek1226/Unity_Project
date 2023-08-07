using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float spawnInterval = 1.0f;
    private float randomInterValStart = 3.0f;
    private float randomIntervalFinish = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        float randomInterval = Random.Range(randomInterValStart, randomIntervalFinish);
        InvokeRepeating("SpawnRandomBall", startDelay, randomInterval);

        //Invoke 보다는 Coroutine 선호
        //문자열호출보단 직접 레퍼런스 활용.
        //StartCoroutine("c");
        //StartCoroutine(c());
    }

    //IEnumerator c()
    //{
    //    yield return null;
    //}
    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
        int randomIdx = Random.Range(0, ballPrefabs.Length);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[randomIdx], spawnPos, ballPrefabs[randomIdx].transform.rotation);
    }

}
