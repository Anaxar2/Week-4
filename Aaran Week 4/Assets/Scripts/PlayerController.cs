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

    // Start is called before the first frame update
    void Start()
    {
     rb = GetComponent<Rigidbody>();
     Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
    if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
         rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //Jump Mechanic.
         isOnGround = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        } else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over");
        }

    }

}

