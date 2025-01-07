using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;       // Reference to the player's Transform
    public Vector3 offset;         // Offset between the camera and the player
    [SerializeField] float smoothSpeed = 0.125f; // Smoothness factor for camera movement
    

    void LateUpdate()
    {
        // Calculate the desired position (player position + offset)
        Vector3 desiredPosition = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);

        // Smoothly interpolate the camera's position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Update the camera's position
        transform.position = smoothedPosition;
        
    }

    
}
