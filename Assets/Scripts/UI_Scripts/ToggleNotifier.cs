using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleNotifier : MonoBehaviour
{
    private Toggle myToggle;
    // Start is called before the first frame update
    void Start()
    {
        myToggle = GetComponent<Toggle>();
        myToggle.onValueChanged.AddListener(
            delegate
            {
                showCurrentValue(myToggle);
                anotherEvent(myToggle, 4);
                otherEvent();
            });
    }

    void showCurrentValue(Toggle toggle)
    {
        if (toggle.isOn)
        {
            Debug.Log("Value: " + toggle.name);
        }
    }

    void anotherEvent(Toggle toggle, int testNumber)
    {
        if (toggle.isOn)
        {
            Debug.Log("We can do this!" + testNumber);
        }
    }

    void otherEvent()
    {
        Debug.Log("no toggle needed as parameter");
    }

}
