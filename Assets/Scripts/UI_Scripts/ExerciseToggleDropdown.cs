using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExerciseToggleDropdown : MonoBehaviour
{
    private DropdownCustom myDropdownClass;
    public GameObject myDropdown;
    // Start is called before the first frame update
    void Start()
    {
        myDropdownClass = myDropdown.GetComponent<DropdownCustom>();
        //Debug.Log(myDropdownClass.getOptionsInToggleGroup().Count);
    }
}
