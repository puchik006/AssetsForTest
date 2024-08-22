using UnityEngine;

public class scr_Enemy_Movement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 4f;
    public Transform player;

    private Vector3 moveDirection;
    private scr_Enemy_Animator enemyAnimator;
    private bool isTouchingPlayer = false;

    private void OnEnable()
    {
        enemyAnimator = GetComponent<scr_Enemy_Animator>();
    }

    void Update()
    {
        if (isTouchingPlayer)
        {
            // Stop the enemy movement and play punch animation
            moveDirection = Vector3.zero;
            enemyAnimator.SetPunch(true);
            enemyAnimator.SetIsForward(false);  // Ensure forward animation stops
            enemyAnimator.SetIsBackward(false); // Ensure backward animation stops
        }
        else
        {
            MoveTowardsPlayer();
        }

        // Apply the move direction to the CharacterController
        controller.Move(moveDirection * Time.deltaTime);
    }

    private void MoveTowardsPlayer()
    {
        if (player != null)
        {
            Vector3 directionToPlayer = player.position - transform.position;
            directionToPlayer.y = 0;
            directionToPlayer.Normalize();

            // Move the enemy towards the player
            moveDirection = directionToPlayer * speed;

            // Determine if the enemy is moving forward or backward
            bool isMovingForward = Vector3.Dot(transform.forward, directionToPlayer) > 0;
            bool isMovingBackward = !isMovingForward;

            // Update the animator with movement information
            enemyAnimator.SetIsForward(isMovingForward);
            enemyAnimator.SetIsBackward(isMovingBackward);

            // Rotate the enemy to face the player
            transform.rotation = Quaternion.LookRotation(directionToPlayer);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            isTouchingPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            isTouchingPlayer = false;
            enemyAnimator.SetPunch(false);
        }
    }
}
