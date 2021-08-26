using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class TradeCupcakeTower : MonoBehaviour, IPointerClickHandler
{
    // Variable to store the sugar meter
    protected static SugarMeterScript sugarMeter;
    // Variable to store the current selected tower by the player
    protected static CupcakeTowerScript currentActiveTower;
    // Start is called before the first frame update
    void Start()
    {
        // If the reference of the Sugar meter is missing, the script gets it
        if (sugarMeter == null)
        {
            sugarMeter = GameObject.FindObjectOfType<SugarMeterScript>();
        }
    }

    // Static function that allow other scripts to assign the new/current
    public static void SetActiveTower(CupcakeTowerScript cupcakeTower)
    {
        currentActiveTower = cupcakeTower;
    }

    // Abstract function triggered when one of the trading button is pressed, however the
    // implementation is specific for each trade operation.
    public abstract void OnPointerClick(PointerEventData eventData);
}
