using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(150)]


public class CameraScript : MonoBehaviour
{
    public Transform player;
    [SerializeField] private InputActionReference mousePosInputAction;
    [SerializeField] private Vector3 lookAtOffset;
    private Vector3 currentLookAtOffset;

    void LateUpdate()
    {
        transform.LookAt(player.position - currentLookAtOffset);
    }
}
