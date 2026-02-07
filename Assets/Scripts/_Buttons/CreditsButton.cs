using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsButton : ButtonScript
{
    public override void ButtonAction()
    {
        ClearSelectorItems();
        SceneManager.LoadScene("Credits");
    }
}
