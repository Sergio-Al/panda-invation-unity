using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownCustom : MonoBehaviour
{
    private Dropdown myDropDown;
    public GameObject listDataToggle;
    // Start is called before the first frame update
    void Start()
    {
        myDropDown = GetComponent<Dropdown>();
        updateDropdownList();
    }

    public void updateDropdownList()
    {
        myDropDown.ClearOptions();
        myDropDown.AddOptions(getOptionsInToggleGroup());
    }

    public List<string> getOptionsInToggleGroup()
    {
        List<string> myList = new List<string>();
        Toggle[] toggleList = listDataToggle.GetComponentsInChildren<Toggle>();

        foreach (Toggle toggle in toggleList)
        {
            if (toggle.isOn)
            {
                myList.Add(toggle.GetComponentInChildren<Text>().text);
            }
        }
        return myList;
    }


}
