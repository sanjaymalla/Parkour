using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject teleporter;
    public float launchForce;
    public Transform shotPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 gunPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - gunPosition;
        transform.right = direction;

        if (Input.GetMouseButtonDown(0)) 
        {
            Shoot();
        } 
    }

    void Shoot()
    {
        GameObject newTeleporter = Instantiate(teleporter, shotPoint.position, shotPoint.rotation);
        newTeleporter.GetComponent<Rigidbody2D>().linearVelocity = transform.right * launchForce;

    }

    
}
