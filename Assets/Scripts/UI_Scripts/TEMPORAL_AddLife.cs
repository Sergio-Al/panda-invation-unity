using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TEMPORAL_AddLife : MonoBehaviour
{
    private Button myButton;
    private HealthBarScript healthReference;
    public GameObject HealthBar;
    // Start is called before the first frame update
    void Start()
    {
        myButton = GetComponent<Button>();
        healthReference = HealthBar.GetComponentInChildren<HealthBarScript>();
        myButton.onClick.AddListener(ApplyFunction);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ApplyFunction()
    {
        healthReference.HealPlayer(10);
    }
}
