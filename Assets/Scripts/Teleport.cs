using UnityEngine;

public class Teleport : MonoBehaviour
{
    private Transform player;
    public GameObject teleporter;

    void Start()
    {
        // Find the player dynamically in the scene (by tag or name)
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player not found! Make sure the player has the correct tag.");
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 hitPoint = collision.contacts[0].point;

        TeleportPlayer(hitPoint);
        
        Destroy(teleporter);

    }

    void TeleportPlayer(Vector2 position)
    {
        if (player != null)
        {
            position += Vector2.up * 0.5f;



            player.position = position;

        }
    }
}
