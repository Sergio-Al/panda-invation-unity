using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpText : MonoBehaviour
{
    private Text popup;
    // Start is called before the first frame update
    void Start()
    {
        popup = GetComponent<Text>();
        popup.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
