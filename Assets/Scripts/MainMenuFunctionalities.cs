using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunctionalities : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Function that loads the first level
    public void NewGame()
    {
        SceneManager.LoadScene(1); // this is from the scene manager in File|Build Settings...
    }

    // Function that displays the settings
    public void Settings()
    {
        // Your fucking code...
    }


    // Function that closes the game
    public void Quit()
    {
        Application.Quit();
    }
}
