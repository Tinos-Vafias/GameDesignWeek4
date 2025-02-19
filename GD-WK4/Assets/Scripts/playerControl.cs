using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public float movSpeed;
    float speedX, speedY;
    [SerializeField] private Slider HPBar;

    public float health;
    Rigidbody2D rb;
    public float maxHealth;

    public bool isAttacking;

    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
   
    public Transform attackPoint;
    public LayerMask healthLayers;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth; 
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal") * movSpeed;
        speedY = Input.GetAxisRaw("Vertical") * movSpeed;
        rb.linearVelocity= new Vector2(speedX, speedY);

        HPBar.value = (health/maxHealth)*100;
        
        //--------------------------------------------NOT DONE--------------------------------------------//
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
        //pick up health object
        Collider2D healthCollider = Physics2D.OverlapCircle(transform.position, attackRange, healthLayers);
        // set pick up radius to attack range for simplicity
        if (healthCollider != null)
        {
            // Check if the collided object has the HealthPickup component
            HealthPickup healthPickup = healthCollider.GetComponent<HealthPickup>();
        
            if (healthPickup != null)
            {
                // Add health and destroy the pickup
                Debug.Log("Player picked up health");
                updateHealth(healthPickup.healthAmount);
                Destroy(healthCollider.gameObject);
            }
        }

    }

    public void updateHealth(float addedVal){
        health += addedVal;
    }

    public void takeDamage(float damageAmount){
        health -= damageAmount;
        Debug.Log("player took damage");
        if (health <- 0){
            //they die
            Debug.Log("player died");
            SceneManager.LoadScene("EndScene");
        }
    }
    public void Attack(){
        Debug.Log("player attacking");
        //detect enemies that are in range of attack and store the enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies){ //apply damage to the enemies
            Debug.Log("we hit " + enemy.name);
            enemy.GetComponent<enemyControl>().TakeDamage(1);
        }
        
    }

    void OnDrawGizmosSelected(){
        if(attackPoint == null){
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
