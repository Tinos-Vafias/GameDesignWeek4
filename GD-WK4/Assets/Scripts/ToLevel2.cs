using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLevel2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    [SerializeField] private string nextSceneName;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player")) // Ensure the Player has the "Player" tag
        {
            string currentScene = SceneManager.GetActiveScene().name; // Get current scene name

            if (currentScene == "Level1")
            {
                Debug.Log("Player reached the end of Level 1! Loading Level 2...");
                SceneManager.LoadScene("Level2"); // Load Level 2
            }
            else if (currentScene == "Level2")
            {
                Debug.Log("Player reached the end of Level 2! Loading End Scene...");
                SceneManager.LoadScene("EndScene"); // Load End Scene
            }
        }
    }
}
