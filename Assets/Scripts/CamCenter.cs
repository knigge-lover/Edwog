using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(100)]

public class CamCenter : MonoBehaviour
{
    [SerializeField] private InputActionReference mousePosInputAction;
    [SerializeField] private CameraScript cameraScript;
    [SerializeField] protected float camRotSpeedx;
    private float x;
    
    void Start()
    {

    }
    
    void LateUpdate()
    {
        x = mousePosInputAction.action.ReadValue<Vector2>().x; 
        transform.position = cameraScript.player.position;
        transform.Rotate(0, (x * camRotSpeedx) * Time.deltaTime, 0);
    }
}
