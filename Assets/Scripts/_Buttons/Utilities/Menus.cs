using UnityEngine;
using System;
using System.Collections.Generic;

[DefaultExecutionOrder(10)]
public class Menus : MonoBehaviour
{
    // ** This script is just for hardcoding stuff, because I don't know where else to put the hardcoded stuff. **
    
    public List<GameObject> hideAtStart;
    
    public Dictionary<string, List<GameObject>> menusDict =
        new Dictionary<string, List<GameObject>>();
    
    [SerializeField] public List<GameObject> main;
    [SerializeField] public List<GameObject> quitConfirm;
    
    private void Start()
    {
        // Main Menu
        main.Add(GameObject.Find("Canvas/playbutton"));
        main.Add(GameObject.Find("Canvas/creditsbutton"));
        main.Add(GameObject.Find("Canvas/quitbutton"));
        
        // Quit Confirmation Menu
        quitConfirm.Add(GameObject.Find("quitno"));
        quitConfirm.Add(GameObject.Find("quityes"));
        
        hideAtStart.AddRange(main);
        hideAtStart.AddRange(quitConfirm);
        
        menusDict.Add("Main", main);
        menusDict.Add("QuitConfirmation", quitConfirm);
    }
}