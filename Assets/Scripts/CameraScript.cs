using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(150)]


public class CameraScript : MonoBehaviour
{
    public Transform player;
    [SerializeField] private InputActionReference mousePosInputAction;
    [SerializeField] private Vector3 lookAtOffset;
    private Vector3 currentLookAtOffset;
    private float camVerticalSensitivity = 0.5f;
    private float camVerticalBorder = 3f;
    private float camVerticalReturnSpeed = 0.1f;

    private void LateUpdate()
    {
        float y = mousePosInputAction.action.ReadValue<Vector2>().y;

        if (currentLookAtOffset.y > camVerticalBorder)
        {
            currentLookAtOffset.y = camVerticalBorder;
            Debug.Log("setting down");
        }
        else if (currentLookAtOffset.y < -camVerticalBorder)
        {
            currentLookAtOffset.y = -camVerticalBorder;
            Debug.Log("setting down");
        }
        else
        {
            currentLookAtOffset += lookAtOffset + new Vector3(0, (y * camVerticalSensitivity * Time.deltaTime) , 0);
            currentLookAtOffset = Vector3.Lerp(currentLookAtOffset, lookAtOffset, camVerticalReturnSpeed * Time.deltaTime);
            Debug.Log("letting");
        }

    }

    void FixedUpdate()
    {
        transform.LookAt(player.position - currentLookAtOffset);
    }
}
