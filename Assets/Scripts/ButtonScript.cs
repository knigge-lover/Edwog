using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ButtonScript : MonoBehaviour
{
    // constant variables
    private float fadeOutSpeed = 3f;
    
    private CanvasGroup canvasGroup;
    protected SelectorScript selector;
    
    // constant serialized-field variables
    [SerializeField] private float driftAwaySpeed = 10f; // Can be accessed individually in the inspector.
    [SerializeField] private ButtonScript[] buttonGroup; // the other buttons that should drift away if this button is pressed.
    
    // non-constant, accessed by script variables
    private float targetPosX;
    private float currentSpeedX;

    [HideInInspector] bool driftAwayB = false;
    
    // FUNCTIONS
    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        selector = GameObject.Find("selector").GetComponent<SelectorScript>();
    }

    public void Update()
    {
        if (driftAwayB)
        {
            DriftAway(driftAwaySpeed);
        }
    }
    
    // This ist the function that generates a smooth drift-away effect if you press the button. 
    public void DriftAway(float speed)
    {
        currentSpeedX += speed;
        transform.Translate(-currentSpeedX * Time.deltaTime, 0, 0);
        canvasGroup.alpha -= Time.deltaTime * fadeOutSpeed;
    }
    
    // Action is what is triggered when the button is pressed, while ButtonAction is the individual action for the button.
    public void Action()
    {
        driftAwayB = true;
        for (int i = 0; i < buttonGroup.Length; i++)
        {
            buttonGroup[i].driftAwayB = true;
        }
        ButtonAction();
    }
    
    // should be overridden, else the button just prints a debug message.
    public virtual void ButtonAction()
    {
        Debug.Log("Following button was just pressed: " + gameObject.name);
    }
}