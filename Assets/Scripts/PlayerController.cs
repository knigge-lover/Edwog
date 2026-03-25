using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(1)]

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;
    [SerializeField] private InputActionReference movenentInputAction;
    [SerializeField] private InputActionReference boostingInputAction;
    [SerializeField] private Transform camCenter;
    [SerializeField] private Transform playerObj;
    [SerializeField] protected Animator playerAnimator;
    private float camLerpSpeed = 0.09f;
    private float playerSpeed = 0.7f;
    private float playerBoostSpeed = 1.5f;
    private float landingHeightBrake = 5f;
    private float landingHeightBrake2 = 0.4f;
    private float falloffSpeed = 0.1f;
    private float falloffSpeed2 = 0.25f;
    private float dtModifier = 50f;

    // define a speed, at what the player swiches to the "walk" animation.
    [SerializeField] private float speedForAnim = 1f;

    // ENCAPSULATION
    public float PlayerSpeed {
        get { return playerSpeed; }
        private set
        { if (value < 0f) { playerSpeed = 0f; } }
    }

    private void Start()
    {
        Application.targetFrameRate = 100;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void OnEscape()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public Vector3 RoundVector3(Vector3 input)
    {
        float x = Mathf.Round(input.x);
        float y = Mathf.Round(input.y);
        float z = Mathf.Round(input.z);

        return new Vector3(x, y, z);
    }

    void FixedUpdate()
    {
        float boosting = boostingInputAction.action.ReadValue<float>();
        float currentSpeed = (boosting * playerBoostSpeed) * playerSpeed + 1;
        if (boosting == 1)
        {
            playerAnimator.SetBool("Boosting", true);
        } else
        {
            playerAnimator.SetBool("Boosting", false);
        }

        //some player movement
        Vector2 direction2d = movenentInputAction.action.ReadValue<Vector2>();
        Vector3 direction3d = new Vector3(-direction2d.y, 0, direction2d.x);
        playerRb.AddForce(camCenter.rotation * direction3d * currentSpeed, ForceMode.VelocityChange);

        //camera stuff
        Vector3 lookAtPos = new Vector3(direction2d.x, 0, direction2d.y);

        Vector3 targetLook = transform.position + camCenter.rotation * lookAtPos;
        Vector3 lerpedTargetLook = Vector3.Lerp(transform.forward + transform.position, targetLook, camLerpSpeed);
        transform.LookAt(lerpedTargetLook);
    }

    
    private void Update()
    {
        //some animation Stuff
        if (playerRb.linearVelocity.magnitude > speedForAnim) {
            playerAnimator.SetBool("Moving", true);
        } else
        {
            playerAnimator.SetBool("Moving", false);
            playerAnimator.SetBool("Boosting", false);
        }

        //raycast stuff to make landings nicer
        Ray landingRay = new Ray(transform.position, Vector3.down);
        RaycastHit groundHit;
        
        if (Physics.Raycast(landingRay, out groundHit, landingHeightBrake))
        {
            if (groundHit.collider.tag == "Ground" && groundHit.distance < landingHeightBrake)
            {
                Vector3 rbVel = playerRb.linearVelocity;
                float adjustedDt = Time.fixedDeltaTime * dtModifier;
                if (groundHit.distance < landingHeightBrake2)
                {
                    rbVel.y = Mathf.Lerp(rbVel.y, falloffSpeed2, falloffSpeed2 * adjustedDt);
                } else
                {
                    rbVel.y = Mathf.Lerp(rbVel.y, falloffSpeed, falloffSpeed * adjustedDt);
                }
                playerRb.linearVelocity = rbVel;
            }
        }
    }
}