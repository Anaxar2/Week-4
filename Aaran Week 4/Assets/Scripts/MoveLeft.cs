using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 8f;
    public float boostSpeed =12;
    private float currentSpeed;
    private float leftBound = -10f;
    private  PlayerController PlayerController;

    // Start is called before the first frame update
    void Start()
    {
        PlayerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()

    {
        if (Input.GetKey(KeyCode.B))
        {
            currentSpeed = boostSpeed;
        }
        else
        {
            currentSpeed = speed;
        }

        if (PlayerController.gameOver == false)
        {
           transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        }

        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }

}
