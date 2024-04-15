using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    public float jumpForce = 5;
    public float gravityModifier;
    bool isOnGround = true;

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
        isOnGround = true;
    }
}

