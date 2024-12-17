using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Obstacles")]
    public GameObject[] obstacles;
    public Vector3 obstaclesPosition = new(25, 0, 0);

    [Header("Rings")]
    public GameObject ring;

    [Header("PowerUps")]
    public GameObject[] powerUps;
    public float delay = 15;
    public float repeat = 30;

    [Header("Rates")]
    public float startDelay = 1;
    public float repeatRate = 2;

    [Header("Player")]
    private PlayerController playerController;

    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        gm = FindAnyObjectByType<GameManager>();

        InvokeRepeating(nameof(SpawnObstacles), startDelay, repeatRate);
        InvokeRepeating(nameof(SpawnRings), startDelay, repeatRate);
        InvokeRepeating(nameof(SpawnPowerUps), delay, repeat);
    }
    private void SpawnObstacles()
    {
        if (playerController.gm.gameOver == false)
        {
            int obstacleIndex = Random.Range(0, obstacles.Length);
            Instantiate(obstacles[obstacleIndex], obstaclesPosition, obstacles[obstacleIndex].transform.rotation);
        }
    }
    private void SpawnRings()
    {
        if (playerController.gm.gameOver == false)
        {
            Vector3 spawnPos = new(Random.Range(30, 41), Random.Range(10, 13), 0);
            Instantiate(ring, spawnPos, ring.transform.rotation);
        }
    }
    public void SpawnPowerUps()
    {
        Vector3 spawnPos = new(Random.Range(30, 41), Random.Range(8, 13), 0);
        int powerUpsIndex = Random.Range(0, powerUps.Length);
        Instantiate(powerUps[powerUpsIndex],spawnPos,powerUps[powerUpsIndex].transform.rotation);
    }
}