using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : ButtonScript
{
    public override void ButtonAction()
    {
        ClearSelectorItems();
        SceneManager.LoadScene("Chapter_1");
    }
}
