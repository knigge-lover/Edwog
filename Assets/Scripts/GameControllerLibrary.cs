using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public static class GameControllerLibrary
{
    //========================================//
    //-----------***Menu Loading***-----------//
    //========================================//
    
    private static void ButtonSetup(GameObject btn, ButtonScript btnScript)
    {
        btn.transform.position += new Vector3(btnScript.spawnPosOffsetForDrift, 0, 0);
        btnScript.spawnDriftActive = true;
        btnScript.driftAwayB = false;
        btnScript.lastXSpawn = btn.transform.position.x;
    }
    
    public static void ClearSelectorItems(int count, SelectorScript selectorScript)
    {
        Array.Clear(selectorScript.positionsOfItems, 0, selectorScript.positionsOfItems.Length);
        selectorScript.positionsOfItems = new GameObject[count];
    }
    
    public static void SetGameObjectsAsInactive(List<GameObject> objects)
    {
        if (objects != null)
        {
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].SetActive(false);
            }
        }
    }
    
    public static void LoadMenu(GameObject[] buttons, Vector3[] positions, SelectorScript selectorScript, bool usePrefabTransform=true)
    {
        if (buttons.Length != positions.Length && !usePrefabTransform)
        {
            Debug.LogWarning("Given lists don't have same length.");
        }
        
        ClearSelectorItems(buttons.Length, selectorScript);
        
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
    
    //=======================================//
    //-----------***Checkpoints***-----------//
    //=======================================//

    public static void SetCheckpoint(int index, GameObject checkpointObj, GameController gameController)
    {
        gameController.checkpointIndex = index;
    }
    
    public static void LoadCheckpoint()
    {
        Debug.Log("Returning to checkpoint...");
    }
}
