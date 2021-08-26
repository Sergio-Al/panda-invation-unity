using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TEMPORALMakeDamage : MonoBehaviour
{
    public GameObject pandaGameObject;
    private PandaScript customPandaScript;
    private Button myButton;
    // Start is called before the first frame update
    void Start()
    {
        myButton = GetComponent<Button>();
        customPandaScript = pandaGameObject.GetComponent<PandaScript>();
        //myButton.onClick.AddListener(makeDamageToPanda); 
    }

    public void makeDamageToPanda()
    {
        // customPandaScript.Hit(20); //hit must be public function, change for test purposes
    }
}
