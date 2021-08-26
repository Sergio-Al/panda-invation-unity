using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ExerciseText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Text myTextComponent;
    private Shadow myTextShadow;
    private RectTransform myRectTransform;
    private Color initColor;
    private bool isOnComponent;

    [Range(5, 15)]
    [Header("Text Shadow Options")]
    public float shadowDistance;
    // Start is called before the first frame update
    void Start()
    {
        initData();
    }

    void Update()
    {
        watchMovingComponent();
    }

    void initData()
    {
        myTextComponent = GetComponentInChildren<Text>();
        myTextShadow = GetComponentInChildren<Shadow>();
        myRectTransform = GetComponentInChildren<RectTransform>();
        initColor = myTextShadow.effectColor;
        isOnComponent = false;
    }

    void watchMovingComponent()
    {
        if (isOnComponent)
        {
            setNewShadow();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isOnComponent = true;
        Debug.Log("Init captured value");
        Debug.Log(Input.mousePosition - myRectTransform.position);
        myTextShadow.effectColor = new Color(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            1f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOnComponent = false;
        myTextShadow.effectColor = initColor;
    }
    
    public void setNewShadow()
    {
        Vector3 capturedShadow = Input.mousePosition - myRectTransform.position;

        float positionX = (capturedShadow.x * -1f) / shadowDistance;
        float positionY = (capturedShadow.y * -1f) / shadowDistance;
        Vector2 newShadow = new Vector2(positionX, positionY);
        myTextShadow.effectDistance = newShadow;
    }
}
