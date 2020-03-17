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

    Vector2 requestedAngle = new Vector2(0, -45);
    Vector2 overriddenAngle = new Vector2(0, -45);
    private float overriddenAnglePercentage = 0.0f;

    [Range(0, 1f)]
    public float overriddenAngleSnapbackMaxValue = 0.0f;
    Vector2 RequestedAngle
    {
        get
        {
            return Vector2.Lerp(requestedAngle, overriddenAngle, overriddenAnglePercentage);
        }
    }

    [SerializeField]
    float[] requestedAngleYBounds = { -89, 0 };

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
        requestedAngle.x = transform.eulerAngles.y;
    }

    public void Zoom(float direction)
    {
        zoomFactor -= direction;
        zoomFactor = Mathf.Clamp(zoomFactor, 0.0f, 1.0f);
    }

    void Update()
    {
        Zoom(Input.mouseScrollDelta.y * 0.1f);

        if (Input.GetMouseButton(1))
        {
            requestedAngle += new Vector2(-Input.GetAxisRaw("CameraX"), Input.GetAxisRaw("CameraY"));
            requestedAngle.y = Mathf.Clamp(requestedAngle.y, requestedAngleYBounds[0], requestedAngleYBounds[1]);
        }
		else
		{
			Vector2 req = target.GetComponent<Movement>().MovementDirectionRequest;
			Vector2 vel = target.GetComponent<Movement>().Velocity;
			float angleOffset = Mathf.Rad2Deg * Mathf.Atan2(-req.x, req.y);
			if (req.sqrMagnitude != 0)
			{
				requestedAngle.x = Mathf.LerpAngle(requestedAngle.x, angleOffset, 1 - velocityBasedAngleCorrection) + 360 % 360;
			}
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            overriddenAngle = requestedAngle;
            overriddenAnglePercentage = 1.0f;
        }

        if (Input.GetMouseButton(0))
        {
            requestedAngle += new Vector2(0, Input.GetAxisRaw("CameraY"));
            requestedAngle.y = Mathf.Clamp(requestedAngle.y, requestedAngleYBounds[0], requestedAngleYBounds[1]);

            overriddenAngle += new Vector2(-Input.GetAxisRaw("CameraX"), 0);
        }
        else
        {
            overriddenAnglePercentage = Mathf.Clamp(overriddenAnglePercentage - (overriddenAngleSnapbackMaxValue * Time.deltaTime), 0, 1);
        }
    }

    void LateUpdate()
    {
        transform.eulerAngles = new Vector3(RequestedAngle.y, 180 - RequestedAngle.x, 0);

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
