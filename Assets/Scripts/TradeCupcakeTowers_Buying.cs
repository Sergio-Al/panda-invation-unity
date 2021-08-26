using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TradeCupcakeTowers_Buying : TradeCupcakeTower
{
    /* public variable to identify wich tower script is selling.
        * Ideally, you could have many instances of this script selling different.
        * Cupcake towers, and the tower is specified in the inspector. 
    */
    public GameObject cupcakeTowerPrefab;

    public override void OnPointerClick(PointerEventData eventData)
    {
        // Retrieve from the prefab wich is its initial cost
        int price = cupcakeTowerPrefab.GetComponent<CupcakeTowerScript>().initialCost;

        // check if the player can afford to buy the tower
        if (price <= sugarMeter.getSugarAmount())
        {
            // Payment succeds, and the cost is removed from the player's sugar.
            sugarMeter.changeSugar(price);
            // A new cupcake tower is created
            GameObject newTower = Instantiate(cupcakeTowerPrefab);
            // The new cupcake tower is also assigned as the current selection
            currentActiveTower = newTower.GetComponent<CupcakeTowerScript>();
        }
    }
}
