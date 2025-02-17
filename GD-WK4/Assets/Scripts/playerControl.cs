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
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal") * movSpeed;
        speedY = Input.GetAxisRaw("Vertical") * movSpeed;
        rb.linearVelocity= new Vector2(speedX, speedY);

        if (Input.GetKey(KeyCode.RightShift)) //to take out once we have enemies
        {
           takeDamage(0.1f);
        }
        HPBar.value = (health/maxHealth)*100;
        
        //--------------------------------------------NOT DONE--------------------------------------------//
        if (Input.GetKey(KeyCode.Space))
        {
           attack();
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
        }
    }

    public void attack(){
        Debug.Log("player attacking");
    }
}
