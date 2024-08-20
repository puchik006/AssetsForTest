using UnityEngine;

public class scr_Player_Camera : MonoBehaviour
{
    public Transform player;   // Reference to the player's transform
    public Vector3 offset;     // Offset distance between the camera and the player

    private void Start()
    {
        // If you haven't set an offset, calculate one based on the initial position
        if (offset == Vector3.zero && player != null)
        {
            offset = transform.position - player.position;
        }
    }

    private void LateUpdate()
    {
        // Ensure the camera follows the player's position while maintaining the offset
        if (player != null)
        {
            transform.position = player.position + offset;
        }
    }
}
