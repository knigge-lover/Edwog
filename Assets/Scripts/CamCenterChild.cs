using UnityEngine;
using UnityEngine.InputSystem;

// INHERITANCE
public class CamCenterChild : MonoBehaviour
{
    [SerializeField] private CamCenter camCenterScript;
    [SerializeField] private InputActionReference mousePosInputAction;
    [SerializeField] protected float camRotSpeedy;
    private const float camBorder = 50f;
    private float y;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        y = -mousePosInputAction.action.ReadValue<Vector2>().y;
        transform.Rotate(0, 0, (y * camRotSpeedy) * Time.deltaTime);
        
        if (transform.localEulerAngles.z > camBorder && transform.localEulerAngles.z < 200)
        {
            transform.localEulerAngles = new Vector3(0,0,camBorder);
        } else if (transform.localEulerAngles.z < 360 - camBorder && transform.localEulerAngles.z > 200)
        {
            transform.localEulerAngles = new Vector3(0,0,-camBorder);
        }
        
    }
}
