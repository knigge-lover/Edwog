using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ButtonScript : MonoBehaviour
{
    // constant variables
    private Vector3 buttonStartPos;
    private CanvasGroup canvasGroup;
    protected SelectorScript selector;
    
    // constant serialized-field variables
    [SerializeField] private float driftAwaySpeed = 10f; // Can be accessed individually in the inspector.
    [SerializeField] private float fadeOutSpeed = 3f;
    
    
    [SerializeField] private ButtonScript[] buttonGroup; // the other buttons that should drift away if this button is pressed.
    
    // non-constant, accessed by script variables
    private float targetPosX;
    private float currentSpeedX;

    [HideInInspector] bool driftAwayB = false;
    
    // FUNCTIONS
    
    private void Awake()
    {
        buttonStartPos = transform.position;
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

        if (canvasGroup.alpha <= 0f)
        {
            Destroy(gameObject);
        }
    }

    public void SpawnDrift(float speed, float targetX)
    {
        float currentPosX = transform.position.x;
        float nextFramePosX = Mathf.Lerp(currentPosX, targetX, speed);
        transform.position = new Vector3(nextFramePosX, transform.position.y, transform.position.z);
    }
    
    public void ClearSelectorItems()
    {
        Array.Clear(selector.positionsOfItems, 0, selector.positionsOfItems.Length);
        selector.positionsOfItems = new GameObject[]{};
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