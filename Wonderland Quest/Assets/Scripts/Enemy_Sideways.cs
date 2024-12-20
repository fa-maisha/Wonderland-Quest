using UnityEngine;

public class Enemy_Sideways : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingLeft)
        {
            if (transform.position.x > leftEdge) 
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
               // transform.localScale = new Vector3(-2.348716, 2.348315, 1.3367);
            }
            else
            {
                movingLeft = false;
            }

        }
        else
        {
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingLeft = true;
            }

        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("enemyspiked");

            playerHealth.TakeDamage(damage);
        }
    }
}
