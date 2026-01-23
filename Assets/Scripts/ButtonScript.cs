using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    protected Button buttonComponentRefrence;
    
    public virtual void Action()
    {
        Debug.Log("Following button was just pressed: " + gameObject.name);
    }
}