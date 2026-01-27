using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;

public class PlayButton : ButtonScript
{
    public override void ButtonAction()
    {
        Array.Clear(selector.positionsOfItems, 0, selector.positionsOfItems.Length);
    }
}
