using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Player_Movement : MonoBehaviour
{
    public CharacterController controller;  // Reference to the CharacterController component
    public float speed = 6f;                // Speed of the player movement
    public scr_UI_Joystick joystick;               // Reference to the on-screen joystick

    private Vector3 moveDirection;          // Direction in which the player moves

    void Update()
    {
        // Get input from the joystick
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        // Calculate the direction to move in
        moveDirection = new Vector3(horizontal, 0f, vertical);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;

        // Move the player
        controller.Move(moveDirection * Time.deltaTime);
    }
}
