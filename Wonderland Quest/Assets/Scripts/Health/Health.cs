using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            // Player hurt
            anim.SetTrigger("hurt");
            //iframes
        }
        else
        {
            // Pleayer dead
            if (!dead)
            {
                anim.SetTrigger("die");
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;
            }
           

        }
    }
    public void GetLife(float life)
    {
        currentHealth = Mathf.Clamp(currentHealth +life, 0, startingHealth);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            TakeDamage(1);

        }
        if(collision.CompareTag("life"))
        {
            GetLife(1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyUp(KeyCode.E))
           // TakeDamage(1);

    }
}