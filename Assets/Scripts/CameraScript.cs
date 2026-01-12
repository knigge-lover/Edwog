using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(150)]


public class CameraScript : MonoBehaviour
{
    public Transform player;
    [SerializeField] private InputActionReference mousePosInputAction;
    [SerializeField] private Vector3 lookAtOffset;
    private Vector3 currentLookAtOffset;
    private float camVerticalSensitivity = .03f;
    private float camVerticalBorder = 10f;
    private float camVerticalReturnSpeed = 1f;
    
    /*
    private void LateUpdate()
    {
        
        float y = mousePosInputAction.action.ReadValue<Vector2>().y;

        if (currentLookAtOffset.y > camVerticalBorder)
        {
            currentLookAtOffset.y = camVerticalBorder;
        }
        else if (currentLookAtOffset.y < -camVerticalBorder)
        {
            currentLookAtOffset.y = -camVerticalBorder;
        }
        else
        {
            currentLookAtOffset += lookAtOffset + new Vector3(0, (y * camVerticalSensitivity) , 0);
            currentLookAtOffset = Vector3.Lerp(currentLookAtOffset, lookAtOffset, camVerticalReturnSpeed * Time.deltaTime);
        }
    }
    */

    void LateUpdate()
    {
        transform.LookAt(player.position - currentLookAtOffset);
    }
}
