using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float RotationSpeed = 200;
    PlayerController pc;
    bool isOnGround;

    // Start is called before the first frame update
    void Start()
    {
     pc = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
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


}
