using UnityEngine;

public class GameController : MonoBehaviour
{
    Vector2 startPos;
    [SerializeField] private Health playerHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }
   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Die();
            
        }
    }
    void Die()
    {

        Respawn();
    }
    void Respawn()
    {
        transform.position = startPos;
    }*/
    // Update is called once per frame
    void Update()
    {
        
    }
}