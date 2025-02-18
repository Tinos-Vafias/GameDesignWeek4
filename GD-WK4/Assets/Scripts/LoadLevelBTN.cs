using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 
public class LoadLevelBTN : MonoBehaviour
{
    public Button myButton; 

    void Start()
    {

    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1"); 
    }
}
