using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 8f;
    public float boostSpeed;
    public float currentSpeed;
    public float leftBound;
    private  PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        DestroyObstacle();
        Boost();

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