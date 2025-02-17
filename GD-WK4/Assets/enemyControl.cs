using UnityEngine;

public class enemyControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float maxHealth;

    public float currHealth;
    public Color newColor;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        currHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
     public void TakeDamage(float damage){
        currHealth -= damage;

        if(currHealth<=0){
            Die();
        }
     }

     void Die(){
        Debug.Log("Enemy died");
        spriteRenderer.color = newColor;
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
     }
   
}

