using UnityEngine;
using UnityEngine.Assertions;
using System.Collections.Generic;

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
    
    public static void LoadMenu(GameObject[] buttons, Transform[] positions)
    {
        if (buttons.Length != positions.Length)
        {
            Debug.LogWarning("Given lists don't have same length.");
        }
    }
}
