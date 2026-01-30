using UnityEngine;
using UnityEngine.Assertions;
using System.Collections.Generic;
using UnityEngine.UI;

[DefaultExecutionOrder(50)]
public class GameController : MonoBehaviour
{
    private Menus menus;
    
    void Start()
    {
        menus = GetComponent<Menus>();
        SetGameObjectsAsInactive(menus.hideAtStart);
        LoadMenu(new GameObject[]{}, new Transform[]{});
        
    }

    private void SetGameObjectsAsInactive(List<GameObject> objects)
    {
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].SetActive(false);
        }
    }
    
    public void LoadMenu(GameObject[] buttons, Transform[] positions, bool usePrefabTransform = false)
    {
        if (buttons.Length != positions.Length && !usePrefabTransform)
        {
            Debug.LogWarning("Given lists don't have same length.");
        }

        for (int i = 0; i < buttons.Length; i++)
        {
            GameObject btn = buttons[i];
            ButtonScript btnScript = btn.GetComponent<ButtonScript>();
            
            if (usePrefabTransform)
            {
                btn.SetActive(true);
                btnScript.ResetTransform();
                btn.transform.position += new Vector3(btnScript.spawnPosOffsetForDrift, 0, 0);
                btnScript.spawnDriftActive = true;
                btnScript.lastXSpawn = btn.transform.position.x;
            }
            else
            {
                Instantiate(buttons[i], positions[i].position, positions[i].rotation);
            }
        }
    }
}
