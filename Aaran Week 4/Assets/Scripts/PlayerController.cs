using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float jumpForce = 5;
    public float gravityModifier;
    bool isOnGround = true;
    public bool gameOver = false;
    public int jumpsLeft = 2;

    // Start is called before the first frame update
    void Start()
    {
     rb = GetComponent<Rigidbody>();
     Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpsLeft > 0 && gameOver == false)
        {
         rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //Jump Mechanic.
         isOnGround = false;
         jumpsLeft--;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // checking if object being collided isOnGround.
        {
            isOnGround = true;
            jumpsLeft = 2;
        } else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true; //setting isOnGround is true.
            Debug.Log("Game Over"); //Display Game Over in Console.
        }

    }

}

