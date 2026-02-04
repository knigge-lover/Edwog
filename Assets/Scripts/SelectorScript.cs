using System;
using UnityEngine.InputSystem;
using UnityEngine;
using System;
using System.Collections;

public class SelectorScript : MonoBehaviour
{ 
    public GameObject[] positionsOfItems;
    public int currentSelectedIndex = 0;
    private float selectorSpeed = 7f;
    private float selectorXOffset = 0f;
    
    void Update()
    {
        if (positionsOfItems.Length != 0)
        {
            Transform item = positionsOfItems[currentSelectedIndex].transform;
            float roundedItemPos = Mathf.Round(10 * positionsOfItems[currentSelectedIndex].transform.position.y) / 10;
            float roundedPos = Mathf.Round(10 * transform.position.y) / 10;
            if (roundedPos != roundedItemPos)
            {
                animate(item);
            }
        }
    }

    public void animate(Transform item)
    {
        float targetLocY = item.position.y;
        float currentLocY = transform.position.y;
        float lerpedLocY = Mathf.Lerp(currentLocY, targetLocY, selectorSpeed * Time.deltaTime);
       
        float targetLocX = item.position.x;
        float currentLocX = transform.position.x - selectorXOffset;
        float lerpedLocX = Mathf.Lerp(currentLocX, targetLocX, selectorSpeed * Time.deltaTime);

        transform.position = new Vector3(lerpedLocX + selectorXOffset, lerpedLocY, transform.position.z);
    }
    
    public void OnUp()
    {
        currentSelectedIndex--;
        if (currentSelectedIndex < 0)
        {
            currentSelectedIndex = positionsOfItems.Length - 1;
        }
    }
    public void OnDown()
    {
        currentSelectedIndex++;
        if (currentSelectedIndex > positionsOfItems.Length - 1)
        {
            currentSelectedIndex = 0;
        }
    }

    public void OnEnter()
    {
        positionsOfItems[currentSelectedIndex].GetComponent<ButtonScript>().Action();
    }
}
