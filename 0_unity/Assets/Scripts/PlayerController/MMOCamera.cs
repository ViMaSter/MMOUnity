using UnityEngine;

public class MMOCamera : MonoBehaviour
{
    #region Basics
    [SerializeField]
    Camera cameraComponent;
    [SerializeField]
    Transform target;

    [SerializeField]
    Vector3 targetOffset = new Vector3(0, 2, 0);
    #endregion

    [SerializeField]
    Vector3[] cameraDistances = { new Vector3(0, 0, 5.0f), new Vector3(0, 0, 10.0f) };
    float zoomFactor = 1.0f;

	private float walkingOffsetInDegrees = 5;

    Vector2 movementDirection = new Vector2(0, -45);
    float scenicDirectionAngle = 0.0f;
    private float scenicAnglePercentage = 0.0f;

    [Range(0, 1f)]
    public float scenicAngleSnapbackMaxValue = 0.75f;
    Vector2 InterpolatedCameraDirection
    {
        get
        {
            return new Vector2(Mathf.Lerp(movementDirection.x, scenicDirectionAngle, scenicAnglePercentage), movementDirection.y);
        }
    }

    [SerializeField]
    float[] cameraAngleYBounds = { -89, 0 };

    float currentTargetY = 0.0f;
	[Range(0, 1)]
    [SerializeField]
    float targetYInterpolation = 0.98f;
	
	[Range(0, 1)]
    [SerializeField]
    float velocityBasedAngleCorrection = 0.98f;

    void Awake()
    {
        transform.rotation = target.rotation;
        movementDirection.x = transform.eulerAngles.y;
    }

    public void Zoom(float direction)
    {
        zoomFactor -= direction;
        zoomFactor = Mathf.Clamp(zoomFactor, 0.0f, 1.0f);
    }

    void Update()
    {
        Zoom(Input.mouseScrollDelta.y * 0.1f);
        
        // override current movement direction based on current camera direction and fully revoke scenic camera transition
        if (Input.GetMouseButtonDown(1))
        {
            movementDirection.x = InterpolatedCameraDirection.x;
            scenicAnglePercentage = 0.0f;
        }

        if (Input.GetMouseButton(1))
        {
            // apply X- and Y-axis update to movement direction
            movementDirection += new Vector2(-Input.GetAxisRaw("CameraX"), Input.GetAxisRaw("CameraY"));
            movementDirection.y = Mathf.Clamp(movementDirection.y, cameraAngleYBounds[0], cameraAngleYBounds[1]);
        }
		else
		{
			Vector2 req = target.GetComponent<Movement>().MovementDirectionRequest;
			Vector2 vel = target.GetComponent<Movement>().Velocity;
			float angleOffset = Mathf.Rad2Deg * Mathf.Atan2(-req.x, req.y);
			if (req.sqrMagnitude != 0)
			{
				movementDirection.x = Mathf.LerpAngle(movementDirection.x, angleOffset, 1 - velocityBasedAngleCorrection) + 360 % 360;
			}
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            // override current visual direction based on current camera direction and fully activate scenic camera transition
            scenicDirectionAngle = InterpolatedCameraDirection.x;
            scenicAnglePercentage = 1.0f;
        }

        if (Input.GetMouseButton(0))
        {
            // apply Y-axis update to movement direction and X-axis update to scenic camera direction
            movementDirection += new Vector2(0, Input.GetAxisRaw("CameraY"));
            movementDirection.y = Mathf.Clamp(movementDirection.y, cameraAngleYBounds[0], cameraAngleYBounds[1]);

            scenicDirectionAngle += -Input.GetAxisRaw("CameraX");
        }
        else
        {
            // slowly reset scenic camera transition
            scenicAnglePercentage = Mathf.Clamp(scenicAnglePercentage - (scenicAngleSnapbackMaxValue * Time.deltaTime), 0, 1);
        }
    }

    public Quaternion GetMovementDirection()
    {
        return Quaternion.Euler(0, -movementDirection.x, 0);
    }

    void LateUpdate()
    {
        transform.eulerAngles = new Vector3(InterpolatedCameraDirection.y, 180 - InterpolatedCameraDirection.x, 0);

        // get curernt zoom distance
        Vector3 distance = Vector3.Lerp(cameraDistances[0], cameraDistances[1], zoomFactor);

        // determine target position with interpolated Y position
        Vector3 targetPosition = target.position;
        targetPosition.y = currentTargetY;

        transform.position = targetPosition + transform.TransformDirection(distance);
        cameraComponent.fieldOfView = 60;

        // finally look at target
        transform.LookAt(targetPosition + targetOffset);
    }
}
