using UnityEngine;
using UnityEngine.Assertions;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Linq;

[DefaultExecutionOrder(50)]
public class GameController : MonoBehaviour
{
    private Menus menus;
    private SelectorScript selectorScript;
    
    void Start()
    {
        selectorScript = GameObject.Find("Canvas/selector").GetComponent<SelectorScript>();
        menus = GetComponent<Menus>();
        SetGameObjectsAsInactive(menus.hideAtStart);
        LoadMenu(menus.main.ToArray(), new Vector3[]{}, true);
    }

    private void SetGameObjectsAsInactive(List<GameObject> objects)
    {
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].SetActive(false);
        }
    }
    
    public void LoadMenu(GameObject[] buttons, Vector3[] positions, bool usePrefabTransform = true)
    {
        if (buttons.Length != positions.Length && !usePrefabTransform)
        {
            Debug.LogWarning("Given lists don't have same length.");
        }
        
        ClearSelectorItems(buttons.Length);
        
        for (int i = 0; i < buttons.Length; i++)
        {
            selectorScript.positionsOfItems[i] = buttons[i];
            GameObject btn = buttons[i];
            ButtonScript btnScript = btn.GetComponent<ButtonScript>();
            
            // We don't use the same func because they have different spawn positions.
            if (usePrefabTransform)
            {
                btn.SetActive(true);
                btnScript.ResetTransform();
                ButtonSetup(btn, btnScript);
            }
            else
            {
                btn.SetActive(true);
                btnScript.ResetTransform(positions[i], true);
                ButtonSetup(btn, btnScript);
            }
        }
        selectorScript.currentSelectedIndex = 0;
    }

    private void ButtonSetup(GameObject btn, ButtonScript btnScript)
    {
        btn.transform.position += new Vector3(btnScript.spawnPosOffsetForDrift, 0, 0);
        btnScript.spawnDriftActive = true;
        btnScript.driftAwayB = false;
        btnScript.lastXSpawn = btn.transform.position.x;
    }
    
    public void ClearSelectorItems(int count)
    {
        Array.Clear(selectorScript.positionsOfItems, 0, selectorScript.positionsOfItems.Length);
        selectorScript.positionsOfItems = new GameObject[count];
    }
}
