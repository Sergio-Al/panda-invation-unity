using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SugarMeterScript : MonoBehaviour
{
    private Text sugarMeter; // Reference to the Text component (by UnityEngine.UI)
    private int sugar; //Amount of sugar that player possesses
    // Start is called before the first frame update
    void Start()
    {
        // Get the reference to the Sugar_Meter_Text
        sugarMeter = GetComponentInChildren<Text>();
        // Update the sugar meter graphic
        updateSugarMeter();

    }

    // Function to decrease or increase the amoung of sugar
    public void changeSugar(int value)
    {
        // Increase (or decrease if the value is negative) the amount of sugar
        sugar += value;
        // Check if the amount of sugar is negative, is so set it to zero
        if (sugar < 0)
        {
            sugar = 0;
        }
        // Update the sugar meter graphics
        updateSugarMeter();
    }

    // Function to return the amount of sugar since sugar is private
    public int getSugarAmount()
    {
        return sugar;
    }

    // function to update the sugar meter graphic
    void updateSugarMeter()
    {
        // Assign the amount of sugar converted to a string to the text in the Sugar Meter.
        sugarMeter.text = sugar.ToString();
    }
}
