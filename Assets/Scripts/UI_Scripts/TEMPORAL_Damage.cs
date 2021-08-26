using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TEMPORAL_Damage : MonoBehaviour
{
    private Button myButton;
    public GameObject healthBar;
    private HealthBarScript healthBarScript;
    // Start is called before the first frame update
    void Start()
    {
        myButton = GetComponent<Button>();
        healthBarScript = healthBar.GetComponent<HealthBarScript>();
        myButton.onClick.AddListener(MakeDamage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeDamage(){
        healthBarScript.ApplyDamage(10);
    }
}
