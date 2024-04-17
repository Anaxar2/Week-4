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
    private Animator playerAnim;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (gm.timer < 0)
        {
            Debug.Log("Game Over!");
            gameOver = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpsLeft > 0 && gameOver == false)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //Jump Mechanic.
            isOnGround = false; // checks if isOnGround is false.
            jumpsLeft--;
            playerAnim.SetTrigger("Jump_trig"); // triggers jump animation.
        }
     
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // checking if object being collided isOnGround.
        {
            isOnGround = true;
            jumpsLeft = 2;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {

            Debug.Log("Game Over"); //Display Game Over in Console.
        }

        if (collision.gameObject.CompareTag("Obstacle")) //checks collisions with obstacles
        {
            gm.healthPoints -= 1; // Reduces health by 1 when hit by obstacle.
            Debug.Log("Hit");


            if (gm.healthPoints == 0) // If health equals 0. Run code below.
            {
             Debug.Log("Game Over!"); // logs Game over.
             gameOver = true; //setting isOnGround is true.
             playerAnim.SetBool("Death_b", true); // sets death is true.
             playerAnim.SetInteger("DeathType_int", 1); // plays Death animation.
            }
        }
           
    }
}