using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    
    

    public void Respawn(Transform spawnpoint)
    {
        transform.position = spawnpoint.position;

        
    }

    
}
