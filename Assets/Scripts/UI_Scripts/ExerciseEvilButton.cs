using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ExerciseEvilButton : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Button myEvilButton;
    PointerEventData pointerED;
    private GameObject bb;
    void Start()
    {
        Debug.Log(gameObject.name);
        myEvilButton = GetComponent<Button>();
        myEvilButton.onClick.AddListener(evilClicked);
        
    }

    void evilClicked()
    {
        Debug.Log("this is clicked! hahaha!");
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Middle)
        {
            Debug.Log("this is clicked through interface EventSystem");
        }

        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("this is clicked through interface Left");
        }
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("you have no escape!");
        }
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("this is entered!");
        }

        if (pointerEventData.IsPointerMoving())
        {
            Debug.Log("No, Stop!");
        }
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("You have left");
        }
    }
}
