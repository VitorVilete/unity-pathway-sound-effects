using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float minTime = 2;
    private float maxTime = 4;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnObstacle", minTime);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void SpawnObstacle()
    {
        if (playerControllerScript.isGameOver == false)
        {
            GameObject obstacleToBeSpawned = obstaclePrefab[Random.Range(0, obstaclePrefab.Length)];
            Instantiate(obstacleToBeSpawned, spawnPos, obstacleToBeSpawned.transform.rotation);
        }

        Invoke("SpawnObstacle", Random.Range(minTime, maxTime));
    }
}
