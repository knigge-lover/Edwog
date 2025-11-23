using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(150)]


public class CameraScript : MonoBehaviour
{
    public Transform player;
    [SerializeField] private InputActionReference mousePosInputAction;
    [SerializeField] private Vector3 lookAtOffset;
    private Vector3 currentLookAtOffset;
    private float rotRetSpeed = 0.1f;

    private void Update()
    {
    }

    void FixedUpdate()
    {
        transform.LookAt(player.position - lookAtOffset);
    }
}
