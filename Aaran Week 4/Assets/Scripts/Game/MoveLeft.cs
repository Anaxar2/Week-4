using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 8f;
    public float boostSpeed;
    public float currentSpeed;
    [SerializeField] float countUp = 0f;
    public float leftBound;
    private  PlayerController playerController;
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        gm = FindAnyObjectByType<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {
        DestroyObstacle();
        Boost();
        SpeedUp();

        if (playerController.gm.gameOver == false)
        {
           transform.Translate(currentSpeed * Time.deltaTime * Vector3.left);
        }
    }
    void DestroyObstacle()
    {
        if (transform.position.x < leftBound && (gameObject.CompareTag("Obstacle") || CompareTag("Ring")))
        {
            Destroy(gameObject);
        }
    }
    void SpeedUp()
    {
        countUp += Time.deltaTime;

        if (gm.gameOver == false && countUp >= 10)
        {
            speed += 2;
            countUp = 0;
        }
    }
    void Boost()
    {
        if (Input.GetKey(KeyCode.B))
        {
            currentSpeed = boostSpeed;
        }
        else
        {
            currentSpeed = speed;
        }
    }
}