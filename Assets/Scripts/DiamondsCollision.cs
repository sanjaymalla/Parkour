using UnityEngine;
using UnityEngine.UI;

public class DiamondsCollision : MonoBehaviour
{
    public static int Diamond = 0;
    public Text scoreText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Diamond++;
            scoreText.text = "Score: "+Diamond;
            Debug.Log("Score");
            Debug.Log(Diamond);
        }
    }
}
