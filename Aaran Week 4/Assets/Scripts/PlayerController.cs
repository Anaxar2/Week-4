using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header ("General")]
    Rigidbody rb;
    private Animator playerAnim;
    public GameManager gm;
    public float Speed;

    [Header ("Jump")]
    public float jumpForce = 5;
    public float gravityModifier;
    public int jumpsLeft = 2;
    bool isOnGround = true;
    public bool gameOver = false;
    
    [Header ("Rotation Mid-air")]
    public float RotationSpeed;

    [Header ("Particle Systems")]
    public ParticleSystem explosion;
    public ParticleSystem dirt;

    [Header("Audio")]
    public AudioClip[] jumpSounds;
    public AudioClip[] crashSounds;
    private AudioSource _as;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        _as = GetComponent<AudioSource>();
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
            playerAnim.SetBool("Grounded", false); //setting Grounded to false.
            dirt.Stop();// stop dirt partlice effect playing when jumping.
            int RandomJumpSounds = Random.Range(0, jumpSounds.Length);
            _as.PlayOneShot(jumpSounds[RandomJumpSounds], 1.0f);
        }
        if (Input.GetKey(KeyCode.RightArrow) && isOnGround == false) // Trigers Frontflip Mechanic on key hold.
        {
            transform.Rotate(Vector3.back * RotationSpeed * Time.deltaTime, Space.World); //Frontflip Mechanic Rotates on z axis.
        }

        if (Input.GetKey(KeyCode.LeftArrow) && isOnGround == false) //Triggers Backflip Mechanic on key press.
        {
            transform.Rotate(Vector3.forward * RotationSpeed * Time.deltaTime, Space.World); //Backflip Mechanic Rotates on z axis
        }

        if (Input.GetKey(KeyCode.UpArrow) && isOnGround == false) //Trigers rotation on the Y axis with key hold.
        {
            transform.Rotate(Vector3.down * RotationSpeed * Time.deltaTime, Space.World); //Midair Rotation Mechanic on Y axis.(LEFT)
        }

        if (Input.GetKey(KeyCode.DownArrow) && isOnGround == false) // Triggers rotation on the Y axis with key hold.
        {
            transform.Rotate(Vector3.up * RotationSpeed * Time.deltaTime, Space.World); //Midair Rotation Mechanic on Y axis. (RIGHT)
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // checking if object being collided isOnGround.
        {
            isOnGround = true; // se
            jumpsLeft = 2;
            dirt.Play();
            playerAnim.SetBool("Grounded", true); // setting Grounded to true.
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
           Debug.Log("Game Over"); //Display Game Over in Console.
           explosion.Play(); //Plays explosion particle effect when hitting Obstacle.
           dirt.Stop(); //Stops dirt particle effect when hitting Obstacle.
            int RandomCrashSounds = Random.Range(0, crashSounds.Length);
            _as.PlayOneShot(jumpSounds[RandomCrashSounds], 1.0f);
        }

        if (collision.gameObject.CompareTag("Obstacle")) //checks collisions with obstacles
        {
            gm.healthPoints -= 1; // Reduces health by 1 when hit by obstacle.
            Debug.Log("Hit");

            if(gm.healthPoints == 0) // If health equals 0. Run code below.
            {
             Debug.Log("Game Over!"); // logs Game over.
             gameOver = true; // Checks if Game Over is true.
             playerAnim.SetBool("Death_b", true); // sets death is true.
             playerAnim.SetInteger("DeathType_int", 1); // plays Death animation.
            }
        }
           
    }
   

}