using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstacles;
    public Vector3 spawnPosition = new Vector3(25,0,0);
    private float startDelay = 2;
    private float repeatRate = 2;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacles", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void SpawnObstacles()
    {
        int obstacleIndex = Random.Range(0, obstacles.Length);
        Instantiate(obstacles[obstacleIndex], spawnPosition, obstacles[obstacleIndex].transform.rotation);

    }

}
