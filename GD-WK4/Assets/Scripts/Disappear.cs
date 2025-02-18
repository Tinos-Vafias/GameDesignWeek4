using UnityEngine;

public class Disappear : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;
    public Collider2D objectCollider;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        objectCollider = GetComponent<Collider2D>();
        if (spriteRenderer == null)
        {
            Debug.LogError(gameObject.name + " is missing a SpriteRenderer! Check the Inspector.");
        }
    }

    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        spriteRenderer.enabled = false;

        if (other.CompareTag("Spotlight"))
        {
            Debug.Log(spriteRenderer.enabled);
            rb.simulated = false;
            objectCollider.enabled = false;
            Debug.Log("Disappear");
            gameObject.SetActive(false);

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Spotlight"))
        {
            Debug.Log("Appear");

            spriteRenderer.enabled = true;
            rb.simulated = true;
            objectCollider.enabled = true;
        }
    }
}