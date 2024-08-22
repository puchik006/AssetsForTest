using UnityEngine;

public class scr_Player_Movement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 6f;
    public scr_UI_Joystick joystick;
    private Vector3 moveDirection;
    private scr_Player_Animator playerAnimator; // Reference to the player animator script

    private void Start()
    {
        // Get the reference to the scr_Player_Animator component
        playerAnimator = GetComponent<scr_Player_Animator>();
    }

    void Update()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        moveDirection = new Vector3(-vertical, 0f, horizontal);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;

        // Move the player
        controller.Move(moveDirection * Time.deltaTime);

        // Determine if the player is moving forward or backward
        bool isMovingForward = horizontal > 0;
        bool isMovingBackward = horizontal < 0;

        // Update the animator with movement information
        playerAnimator.SetIsForward(isMovingForward);
        playerAnimator.SetIsBackward(isMovingBackward);
    }
}

