using UnityEngine;

public class QuitButton : ButtonScript
{
    public override void ButtonAction()
    {
        Application.Quit();
    }
}
