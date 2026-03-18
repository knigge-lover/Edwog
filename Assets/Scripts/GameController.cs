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
        GameControllerLibrary.SetGameObjectsAsInactive(menus.hideAtStart);
        GameControllerLibrary.LoadMenu(
            menus.main.ToArray(),
            new Vector3[]{},
            selectorScript,
            true
        );
    }
}
