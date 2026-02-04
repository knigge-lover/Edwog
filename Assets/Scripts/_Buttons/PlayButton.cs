using System;
using UnityEngine;

public class PlayButton : ButtonScript
{
    private bool clicked = false;
    
    protected override void ButtonUpdate()
    {
        
    }
    
    public override void ButtonAction()
    {
        ClearSelectorItems();
        clicked = true;
    }
}
