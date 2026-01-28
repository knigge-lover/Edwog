using System;
using _Buttons;
using Unity.VisualScripting;
using UnityEngine;

public class QuitButton : ButtonScript
{
    [SerializeField] private ButtonModeEnum mode; // 0 = quit button, 1 = confirmation - yes, 2 = confirmation - no. 
    

    public override void ButtonAction()
    {
        if (mode == ButtonModeEnum.Quit)
        {
            
        } else if (mode == ButtonModeEnum.Cancel)
        {
            //LoadMenu();
        } else if (mode == ButtonModeEnum.Confirmation)
        {
            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false; // just if programmer is in the unity editor...
            Debug.Log("Application has been quitted, this may not work in the unity editor.");
        } else
        {
            Debug.LogWarning("Unknown enum type detected!");
        }
    }
}
