using UnityEngine;
using UnityEngine.Assertions;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Linq;
using Unity.VectorGraphics;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(50)]
public class GameController : MonoBehaviour
{
    private Menus menus;
    private SelectorScript selectorScript;
    public static GameController instance; 
    public int checkpointIndex;

    private string menuSceneName = "Menu";

    private void Awake()
    {
        menus = GetComponent<Menus>();
        DontDestroyOnLoad(gameObject);
        if (instance != this)
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().name == menuSceneName)
        {
            selectorScript = GameObject.Find("Canvas/selector").GetComponent<SelectorScript>();
            GameControllerLibrary.SetGameObjectsAsInactive(menus.hideAtStart);
            GameControllerLibrary.LoadMenu(
                menus.main.ToArray(),
                new Vector3[]{},
                selectorScript,
                true
            );
        }
    }
}
