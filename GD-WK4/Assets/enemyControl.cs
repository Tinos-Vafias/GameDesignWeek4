using UnityEngine;

public class enemyControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float maxHealth;

    public float currHealth;
    public Color newColor;
    private SpriteRenderer spriteRenderer;

    public float movSpeed;

    public GameObject pointA;
    public GameObject pointB;
    private Transform currentPoint;
    private Rigidbody2D rb;

    public Transform player;
    public float detectionRange;
    public float attackRange;
    public float enemyAttack;
    
    private Color defaultColor;
    private bool isFollowing;
    private Vector2 lastPatrolPt;

    void Start()
    {
        currHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultColor = spriteRenderer.color;

        currentPoint = pointB.transform;

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // make sure player exists
        if (player == null) return ;
        // check how close player is
        if (Vector2.Distance(transform.position, player.position) <= detectionRange)
        {
            lastPatrolPt = currentPoint.position;
            followPlayer();
        }
        else
        {
            patrol();
        }
    }
    public void TakeDamage(float damage)
    {
        currHealth -= damage;
        if(currHealth<=0){
            Die();
        }
    }

    void Die(){
        Debug.Log("Enemy died");
        spriteRenderer.enabled = false; // just make it disappear completely
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
   
    void patrol()
    {
        spriteRenderer.color = defaultColor;

        Vector2 direction = (currentPoint.position - transform.position).normalized;

        rb.linearVelocity = direction * movSpeed;

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f)
        {
            if (currentPoint == pointA.transform)
            {
                currentPoint = pointB.transform;
            }
            else
            {
                currentPoint = pointA.transform;
            }        
        }
    }
    
    void followPlayer()
    {
        // Debug.Log("following player");
        spriteRenderer.color = newColor; // change color to know when it found player

        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * movSpeed;
        if (Vector2.Distance(transform.position, player.position) <= attackRange)
        {
            attackPlayer();
        }
    }
    
    void attackPlayer() 
    {   
        player.GetComponent<PlayerControl>().takeDamage(enemyAttack);
    }
}

