using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    private InputField myInputField;
    public GameObject myDropdownList;
    public GameObject toggleObject;
    public GameObject dropDownCustom;
    private Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        myInputField = GetComponent<InputField>();
        myInputField.onEndEdit.AddListener(delegate { modifyToggleList(myInputField); });
        position = toggleObject.GetComponent<RectTransform>().anchoredPosition3D;
        position.y -= 20;
    }

    void modifyToggleList(InputField inputField)
    {
        Debug.Log(myInputField.text);
        GameObject newToggle = GameObject.Instantiate(toggleObject);

        newToggle.GetComponent<Toggle>().name = inputField.text;
        newToggle.GetComponentInChildren<Text>().text = inputField.text;
        newToggle.transform.SetParent(myDropdownList.transform);


        newToggle.GetComponent<RectTransform>().anchoredPosition = position;

        position.y -= 20;
        dropDownCustom.GetComponent<DropdownCustom>().updateDropdownList();
        inputField.text = "";
    }
}
