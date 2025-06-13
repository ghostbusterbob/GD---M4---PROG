using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    void Update()                      //Zorg dat de code elk frame wordt uitgevoerd
    {
        if (Input.GetKeyDown(KeyCode.Space))     //Check of de speler de spatie indrukt
        {
            SceneManager.LoadScene("GameScene");  //Laad de "GameScene" in met de LoadScene methode
        }
    }
}