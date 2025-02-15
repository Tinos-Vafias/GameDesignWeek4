using System.Collections;
using System.Collections.Generic;
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }

    // Update is called once per frame
    public void updateHealthBar(float currHealth, float maxHealth){
        HPBar.value = currHealth/maxHealth;
    }

    void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal") * movSpeed;
        speedY = Input.GetAxisRaw("Vertical") * movSpeed;
        rb.linearVelocity= new Vector2(speedX, speedY);

        if (Input.GetKey(KeyCode.RightShift))
        {
           takeDamage(0.1f);
        }
        HPBar.value = (health/maxHealth)*100;
        
    }

    
    public void takeDamage(float damageAmount){
        health -= damageAmount;
        if (health <- 0){
            //they die
        }
    }
}
