using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [Header("This is a main string!")]
    public int testVariable;
    [HideInInspector]
    public int myVariableHidden;
    [Range(-10, 10)]
    [Tooltip("this is for test you Range to adjust the velocit of the car")]
    public int myRangeTestVariable;
    [Tooltip("This is for testing porpuses")]
    public int myTooltipVariable;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("this is you variable: " + testVariable);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
