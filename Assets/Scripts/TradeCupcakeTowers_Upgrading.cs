using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class TradeCupcakeTowers_Upgrading : TradeCupcakeTower
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        // Check if the player can afford to upgrade the tower
        if (currentActiveTower.isUpgradable && currentActiveTower.upgradingCost <= sugarMeter.getSugarAmount())
        {
            // The payment is executed and the sugar is removed from the player
            sugarMeter.changeSugar(currentActiveTower.upgradingCost);
            // The tower is upgraded
            currentActiveTower.Upgrade();
        }
    }
}
