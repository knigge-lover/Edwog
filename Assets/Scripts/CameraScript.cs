using UnityEngine;

[DefaultExecutionOrder(150)]


public class CameraScript : MonoBehaviour
{
    public Transform player;
    [SerializeField] private Vector3 lookAtOffset;

    void FixedUpdate()
    {
        transform.LookAt(player.position - lookAtOffset);
    }
}
