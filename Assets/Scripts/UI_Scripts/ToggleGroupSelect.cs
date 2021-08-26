using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleGroupSelect : MonoBehaviour
{
    private ToggleGroup myToggleGroup;
    public bool changedValue;
    private IEnumerable<Toggle> myChoice;
    // Start is called before the first frame update
    void Start()
    {
        myToggleGroup = GetComponent<ToggleGroup>();
        // IEnumerable (ActiveToggles) return a list of an interface with yield or something like that :|
        foreach(Toggle t in myToggleGroup.ActiveToggles())
        {
            Debug.Log(t.name.ToString());
        }
        
    }

    public string getNameSelectedToggle()
    {
        return myToggleGroup.GetFirstActiveToggle().name.ToString();
    }
}
