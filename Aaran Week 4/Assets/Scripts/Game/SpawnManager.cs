using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Obstacles")]
    public GameObject[] obstacles;
    public Vector3 obstaclesPosition = new (25,0,0);

    [Header("Rings")]
    public GameObject ring;

    [Header("Rates")]
    public float startDelay = 1;
    public float repeatRate = 2;

    [Header("Player")]
    private PlayerController playerController;

    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnObstacles), startDelay, repeatRate);
        InvokeRepeating(nameof(SpawnRings), startDelay, repeatRate);
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        gm = FindAnyObjectByType<GameManager>();
    }
    private void SpawnObstacles()
    {
        if(playerController.gm.gameOver == false)
        {
            int obstacleIndex = Random.Range(0, obstacles.Length);
            Instantiate(obstacles[obstacleIndex], obstaclesPosition, obstacles[obstacleIndex].transform.rotation);
        }
    }
    private void SpawnRings()
    {
        if (playerController.gm.gameOver == false)
        {
            Vector3 randomSpawnPos = new (Random.Range(30, 40), Random.Range(8,13), 0);
            Instantiate(ring,randomSpawnPos, ring.transform.rotation);  
        }
    }
}
