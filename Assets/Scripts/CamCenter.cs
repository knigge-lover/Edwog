using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(100)]

public class CamCenter : MonoBehaviour
{
    [SerializeField] private InputActionReference mousePosInputAction;
    [SerializeField] private float camFollowSpeed;
    [SerializeField] private CameraScript cameraScript;

    private void Start()
    {

    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, cameraScript.player.position, camFollowSpeed);
        transform.Rotate(new Vector3(0, mousePosInputAction.action.ReadValue<Vector2>().x, 0));
    }
}
