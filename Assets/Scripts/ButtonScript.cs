using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Vector2 = System.Numerics.Vector2;

public class ButtonScript : MonoBehaviour
{
    // INHERITANCE
    // multiple button-scripts inherit from this script.
    // I write this because this project is the submission of the Junior Programmer unity learn pathway.
    
    // constant variables
    public Menus menus;
    public GameController gameController;
    private float buttonStartPosX;
    private CanvasGroup canvasGroup;
    protected SelectorScript selector;
    
    // constant serialized-field variables
    [SerializeField] private float driftAwaySpeed = 10f; // Can be accessed individually in the inspector.
    [SerializeField] private float fadeOutSpeed = 3f;

    [SerializeField] private float spawnDriftSpeed = 10f;
    
    [SerializeField] public float spawnPosOffsetForDrift = 100f;
    
    [SerializeField] private ButtonScript[] buttonGroup; // the other buttons that should drift away if this button is pressed.
    
    // non-constant, accessed by script variables
    private float targetPosX;
    private float currentSpeedX;
    public bool spawnDriftActive = false;
    [HideInInspector] public bool driftAwayB = false;
    public float lastXSpawn = 0f;
    
    // FUNCTIONS
    
    private void Start()
    {
        buttonStartPosX = transform.position.x;
        gameController = GameObject.Find("GameManager").GetComponent<GameController>();
        menus = GameObject.Find("GameManager").GetComponent<Menus>();
        canvasGroup = GetComponent<CanvasGroup>();
        selector = GameObject.Find("selector").GetComponent<SelectorScript>();
    }

    public void Update()
    {
        if (driftAwayB)
        {
            DriftAway(driftAwaySpeed);
        }
        else if (spawnDriftActive)
        {
            SpawnDrift(spawnDriftSpeed, buttonStartPosX);
        }
    }
    
    public void ResetTransform(Vector3 positions = new Vector3(), bool useDifferentPositions = false)
    {
        Vector3 pos;
        if (!useDifferentPositions)
        {
            pos = new Vector3(buttonStartPosX, transform.position.y, transform.position.z);
        }
        else
        {
            pos = positions;
        }

        transform.position = pos;
    }
    
    // This ist the function that generates a smooth drift-away effect if you press the button. 
    public void DriftAway(float speed)
    {
        currentSpeedX += speed;
        transform.Translate(-currentSpeedX * Time.deltaTime, 0, 0);
        canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, 0, Time.deltaTime * fadeOutSpeed);

        if (canvasGroup.alpha <= 0.001f)
        {
            driftAwayB = false;
            spawnDriftActive = false;
            gameObject.SetActive(false);
        }
    }

    public void SpawnDrift(float speed, float targetX)
    {
        float roundedX = Mathf.Round(transform.position.x);
        float roundedTargetX = Mathf.Round(targetX);
        
        //if conditions is just here for optimisation. so we don't have to Lerp everything even if it ist at the right position.
        if (roundedX != roundedTargetX)
        {
            float currentPosX = transform.position.x;
            float nextFramePosX = Mathf.Lerp(currentPosX, targetX, speed * Time.deltaTime);
            transform.position = new Vector3(nextFramePosX, transform.position.y, transform.position.z);

            // it's "simple" math to calculate the alpha.
            float alpha = 1 - (nextFramePosX - targetX) / Mathf.Abs(targetX - lastXSpawn);
            canvasGroup.alpha = alpha;
        }
        else { spawnDriftActive = false; }
    }
    
    public void ClearSelectorItems()
    {
        Array.Clear(selector.positionsOfItems, 0, selector.positionsOfItems.Length);
        selector.positionsOfItems = new GameObject[]{};
    }
    
    // Action is what is triggered when the button is pressed, while ButtonAction is the individual action for the button.
    public virtual void Action()
    {
        driftAwayB = true;
        spawnDriftActive = false;
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