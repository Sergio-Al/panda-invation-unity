using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public struct PandaExp
{
    public int numberOfPandas;
    public int secondsToWait;
    public int rewardPerWave;
}
public class GameManagerScript : MonoBehaviour
{
    public Waypoint firstWaypoint;
    // Variable to store the displayed when the player loses
    public GameObject losingScreen;
    // Variable to store the screen displayed when the player wins
    public GameObject winningScreen;
    // The panda prefab that should be spawned as enemy
    public GameObject pandaPrefab;

    public PandaExp[] wavesPerPanda;
    // Sugar Meter GameObject
    public GameObject sugarMeter;
    // Initial Sugar amount
    public int initialSugar;
    // Private variable to check if the mouse is hovering an area where
    // cupcake tower can be placed
    private bool _isPointerOnAllowedArea = true;
    // Private variable to store the reference to the Player's health
    private HealthBarScript playerHealth;
    // Private variable which acts as a counter of how many Pandas are remainded to defeat
    private int numberOfPandasToDefeat;
    // The Spawning Poitn transform so to get where the Pandas should be spanwned
    private Transform spawner;

    void Start()
    {
        // Get the reference to the Player's Health
        playerHealth = FindObjectOfType<HealthBarScript>();

        // Get the reference to the spawner
        spawner = GameObject.Find("SpawningPoint").transform;

        // Set the initial sugar amount
        // sugarMeter.GetComponent<SugarMeterScript>().changeSugar(initialSugar);


        StartCoroutine(WavesSpawner());
    }

    void Update()
    {
        Debug.Log("Game Manager" + isPointerOnAllowedArea());
    }

    // function that returns true if the mouse is hovering an area where a
    // Cupcake tower can be placed
    public bool isPointerOnAllowedArea()
    {
        return _isPointerOnAllowedArea;
    }

    // Function wich is called when the mouse enters in one of the
    // colliders of the game manager
    void OnMouseEnter()
    {
        Debug.Log("you has entered");
        // Set that the mouse is now hovering an area where placing cupcake
        // towers is allowed
        _isPointerOnAllowedArea = true;
    }

    // Function which is called when the mouse exits from one of the
    // colliders of the Game Manager
    void OnMouseExit()
    {
        // Set that the mouse is not hovering anymore an area where
        // placing cupcake towers is allowed
        _isPointerOnAllowedArea = false;
    }

    // Private function called when some gameover cnditions are met, and displays
    // The winning or losing screen depending from the value of the parameter passed
    private void GameOver(bool playerHasWon)
    {
        // Check if the player has won from the parameter
        if (playerHasWon)
        {
            // Display the winning screen
            winningScreen.SetActive(true);
        }
        else
        {
            // Display the losing screen
            losingScreen.SetActive(true);
        }
        // Freeze the game time, so to stop in some way the level to be executed
        //Time.timeScale = 0; // this is an interesting funciton to have in account
        StartCoroutine(ReturnToMainMenu());
    }

    // Function that decreases the number of Pandas still to defeat every time a Panda dies
    public void OneMorePandaInHeaven()
    {
        numberOfPandasToDefeat--;
    }

    // Function that damages the player when a Panda reaches the player's cake.
    // Moreover, it monitors the player's health to trigger the gameOver function when needed
    public void BiteTheCake(int damage)
    {
        // Apply damage to the player and retrieve a boolean to see if the cake has been eaten all
        bool IsCakeAllEaten = playerHealth.ApplyDamage(damage);

        // if the cake has been eaten all, the GameOver function is called in "losing mode"
        if (IsCakeAllEaten)
        {
            GameOver(false);
        }
        // the panda that bit the cake will also explode, and therefore we have a panda less to defeat.
        OneMorePandaInHeaven();
    }

    // Coroutine tha spawn the different waves of Pandas
    private IEnumerator WavesSpawner()
    {
        // for each wave
        for (int i = 0; i < wavesPerPanda.Length; i++)
        {
            yield return new WaitForSeconds(wavesPerPanda[i].secondsToWait);
            // Let the PandaSpawner coroutine to handle the single wave. When it finishes
            // also the wave is finished, and so this coroutine can continue.
            yield return PandaSpawner(wavesPerPanda[i].numberOfPandas);
            FindObjectOfType<SugarMeterScript>().changeSugar(wavesPerPanda[i].rewardPerWave);
        }

        // if the player won all the waves, call the GameOver function in "winning" mode
        GameOver(true);
    }

    // Coroutine that spawns the panda for a single wave, and wait until "all the pandas are in heaven"
    private IEnumerator PandaSpawner(int numberOfPandas)
    {
        // Initialize the number that needs to be defeated for this wave
        numberOfPandasToDefeat = numberOfPandas;
        // Progressively spawn Pandas
        for (int i = 0; i < numberOfPandas; i++)
        {
            // Spawn/Intantiate a Panda at the Spawner position
            Instantiate(pandaPrefab, spawner.position, Quaternion.identity);

            // Wait a time that depends both on how many Pandas are left to be
            // Spawned and by a random number
            float ratio = (i * 1f) / (numberOfPandas - 1);
            float timeToWait = Mathf.Lerp(3f, 5f, ratio) + Random.Range(0f, 2f);
            yield return new WaitForSeconds(timeToWait);
        }

        // Once all the Pandas are spawned, wait until all of them are defeated
        // by the player (or a gameover condition ocurred before)
        yield return new WaitUntil(() => numberOfPandasToDefeat <= 0 && FindObjectsOfType<PandaScript>().Length <= 0);

    }

    private IEnumerator ReturnToMainMenu()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }

}

