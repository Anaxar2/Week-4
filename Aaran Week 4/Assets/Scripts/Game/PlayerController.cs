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

    [Header ("Jump")]
    public float jumpForce = 5;
    public float gravityModifier;
    public int jumpsLeft = 2;
    bool isOnGround = true;
    
    [Header ("Rotation Mid-air")]
    public float RotationSpeed;

    [Header ("Particle Systems")]
    public ParticleSystem explosion;
    public ParticleSystem dirt;

    [Header("Audio")]
    public AudioClip[] jumpSounds;
    public AudioClip[] crashSounds;
    private AudioSource _as;

    [Header("Game Over")]
    public bool gameOver;

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
        Jump();
        Frontflip();
        Backflip();
        LeftSpin();
        RightSpin();
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpsLeft > 0 && gameOver == false)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);     // Jump Mechanic.
            isOnGround = false;                                         // Checks if isOnGround is false.
            jumpsLeft--;                                                // Reduces Jumps left when used.
            playerAnim.SetTrigger("Jump_trig");                         // Triggers jump animation.
            playerAnim.SetBool("Grounded", false);                      // Setting the Grounded animation to false.
            dirt.Stop();                                                // Stop dirt partlice effect playing when jumping.
            int RandomJumpSounds = Random.Range(0, jumpSounds.Length);  // Array of lenth x Jump sounds.
            _as.PlayOneShot(jumpSounds[RandomJumpSounds], 1.0f);        // Plays a Random jump sound from the array. 
        }
    }
    private void Frontflip()
    {
        if (Input.GetKey(KeyCode.RightArrow) && isOnGround == false)                         // Trigers Frontflip Mechanic on key hold.
        {
            transform.Rotate(RotationSpeed * Time.deltaTime * Vector3.back, Space.World);    // Frontflip Mechanic Rotates on z axis.
        }
    }
    private void Backflip()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && isOnGround == false)                          // Triggers Backflip Mechanic on key press.
        {
            transform.Rotate(RotationSpeed * Time.deltaTime * Vector3.forward, Space.World); // Backflip Mechanic Rotates on z axis
        }
    }
    private void LeftSpin()
    {
        if (Input.GetKey(KeyCode.UpArrow) && isOnGround == false)                            // Trigers rotation on the Y axis with key hold.
        {
            transform.Rotate(RotationSpeed * Time.deltaTime * Vector3.down, Space.World);    // Midair Rotation Mechanic on Y axis.(LEFT)
        }
    }
    private void RightSpin()
    {
        if (Input.GetKey(KeyCode.DownArrow) && isOnGround == false)                          // Triggers rotation on the Y axis with key hold.
        {
            transform.Rotate(RotationSpeed * Time.deltaTime * Vector3.up, Space.World);      // Midair Rotation Mechanic on Y axis. (RIGHT)
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))                   // Checking if object being collided isOnGround.
        {
            isOnGround = true;                                           // Sets isOnGround to true.
            jumpsLeft = 2;                                               // Sets Jumps left to 2.
            dirt.Play();                                                 // Plays dirt particle effect.
            playerAnim.SetBool("Grounded", true);                        // Sets Grounded Animation to true.
        }

        if (collision.gameObject.CompareTag("Obstacle"))                 // Checks collisions with obstacles
        {
            gm.healthPoints -= 1;                                        // Reduces health by 1 when hit by obstacle.
            Debug.Log("Hit");

            explosion.Play();                                            // Plays explosion particle effect when hitting Obstacle.
            dirt.Stop();                                                 // Stops dirt particle effect when hitting Obstacle.
            int RandomCrashSounds = Random.Range(0, crashSounds.Length); // Array of lenth x Crash sounds.
            _as.PlayOneShot(crashSounds[RandomCrashSounds], 1.0f);       // Plays a Random Crash sound from the array. 
        }
        else if (gm.healthPoints == 0)                                   // If health equals 0. Run code below.
        {
            Debug.Log("Game Over!");                                     // Logs Game over.
            gameOver = true;                                             // Checks if Game Over is true.
            dirt.Stop();                                                 // Stops dirt particle effect when hitting Obstacle.
            playerAnim.SetBool("Death_b", true);                         // Sets death is true.
            playerAnim.SetInteger("DeathType_int", 1);                   // Plays Death animation.
            gm.gameOver.gameObject.SetActive(true);                      // Game Over UI is Set
        }
    }
}