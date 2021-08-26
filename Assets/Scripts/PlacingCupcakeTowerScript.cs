using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlacingCupcakeTowerScript : MonoBehaviour
{
    // Private variable to store the reference to the Game Manager
    private GameManagerScript gameManager;
    // Start is called before the first frame update
    void Start()
    {
        // Get the reference to the game Manager
        gameManager = FindObjectOfType<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // get the mouse position
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;

        /* Place the Cupcake Tower where the mouse is, transformed in game coordinates
          * from the Main Camera. Since the camera is placed at -10 and we want the 
          * tower to be at -3, we need to use 7 as z-axis coordinate */
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 7));

        // if the player clicks, the second condition checks if the current position is
        // within an area where cupcake tower can be placed.
        Debug.Log("your placing state" + (gameManager.isPointerOnAllowedArea()));
        if (Input.GetMouseButtonDown(0) && gameManager.isPointerOnAllowedArea())
        {
            // Enabling again the main cupcake tower script, so to made it operative
            GetComponent<CupcakeTowerScript>().enabled = true;

            // Place a collider on the cupcake tower
            gameObject.AddComponent<BoxCollider2D>();

            // Remove this script, so to not keeping the cupcake tower on the mouse
            Destroy(this);
        }
    }
}
