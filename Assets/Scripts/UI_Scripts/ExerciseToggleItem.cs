using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExerciseToggleItem : MonoBehaviour
{
    private DropdownCustom myDropdown;
    public GameObject dropdownToCustom;
    private Toggle myToggle;
    // Start is called before the first frame update
    void Start()
    {
        myToggle = GetComponent<Toggle>();
        myDropdown = dropdownToCustom.GetComponent<DropdownCustom>();
        myToggle.onValueChanged.AddListener(delegate { updateDropdown(myToggle); });
    }

    void updateDropdown(Toggle toggle)
    {
        dropdownToCustom.GetComponent<DropdownCustom>().updateDropdownList();
    }
}
