using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public int maxHealth; //The maximun amount of health that the player can posses.
    public GameObject popup;
    private Text popupText;
    private Image fillingImage; //The reference to "Health_Bar_filling" image component.
    private int health; //The current amount of health of the player.
    private float timeRemain;
    private bool isTimerActive;
    private bool hasPopupActivated;
    // Start is called before the first frame update
    void Start()
    {
        //Get a reference to the current image
        fillingImage = GetComponentInChildren<Image>();
        popupText = popup.GetComponent<Text>();

        //Set the health to the maximum.
        health = maxHealth;
        hasPopupActivated = false;
        //Update the graphics of the health Bar.
        UpdateHealthBar();

    }

    void Update()
    {
        counterRunning(Time.deltaTime);
    }

    private void startCounter(bool isActive, float timeActive, Text popupToDisplay, string message)
    {
        if (!hasPopupActivated)
        {
            isTimerActive = isActive;
            timeRemain = timeActive;
            popupToDisplay.text = message;
            popupToDisplay.enabled = true;
            hasPopupActivated = true;
        }

    }

    public void counterRunning(float deltaTime)
    {
        if (isTimerActive)
        {
            if (timeRemain > 0)
            {
                timeRemain -= deltaTime;
            }
            else
            {
                Debug.Log("your time has running out!");
                isTimerActive = false;
                popupText.text = "";
                popupText.enabled = false;
                timeRemain = 0;
            }
        }
    }

    public bool ApplyDamage(int value)
    {
        if (value < 0)
        {
            value = 0;
        }
        // Apply Damage to the player.
        health -= value;

        // Check if the player has still health and update the health bar.
        if (health > 0)
        {
            UpdateHealthBar();
            return false;
        }

        // In the case the player has no health left, set the health to zero and return true
        health = 0;
        UpdateHealthBar();
        return true;
    }

    public bool HealPlayer(int value)
    {
        if (health == maxHealth)
        {
            Debug.Log("Your health is on max player.");
            return false;
        }

        health += value;
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        UpdateHealthBar();
        return true;
    }

    // Function to update the health bar graphic.
    void UpdateHealthBar()
    {
        // Calculate the percentage (from 0% to 100%) of the current amount of health of the player.
        float percentage = health * 1f / maxHealth;
        if (percentage < 0.3)
        {
            startCounter(true, 3, popupText, "The pandas are devouring the cake");
        }
        else
        {
            hasPopupActivated = false;
        }
        if (percentage < 0.2)
        {
            fillingImage.color = Color.red;
        }
        else if (percentage >= 0.2 && percentage <= 0.4)
        {
            fillingImage.color = Color.yellow;
        }
        else
        {
            fillingImage.color = Color.green;
        }
        // Assign the percentage to the filling amount variable of the "Health Bar Filling"
        fillingImage.fillAmount = percentage;
    }
}
