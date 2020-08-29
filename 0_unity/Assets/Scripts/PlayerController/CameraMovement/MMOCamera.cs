using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class MMOCamera : MonoBehaviour
{
    #region Basics
    [SerializeField]
    Camera cameraComponent = default;
    [SerializeField]
    Transform target = default;

    [SerializeField]
    Vector3 targetOffset = new Vector3(0, 2, 0);
    #endregion

    [SerializeField]
    Vector3[] zoomTargetOffsetBounds = { new Vector3(0, 0, 5.0f), new Vector3(0, 0, 10.0f) };
    float zoomFactor = 1.0f;

    Vector2 movementDirection = new Vector2(0, -45);
    float scenicDirectionAngle = 0.0f;
    private float scenicAnglePercentage = 0.0f;

    [SerializeField]
    [Range(0, 1f)]
    float scenicAngleSnapbackMaxValue = 0.75f;
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
    float velocityBasedAngleCorrection = 0.98f;

    private Generated.GameControls gameControls;

    [Serializable]
    public enum CameraInputMode
    {
        NONE = 0,
        SCENIC,
        MOVEMENT
    };

    void Awake()
    {
        gameControls = new Generated.GameControls();

        transform.rotation = target.rotation;
        movementDirection.x = transform.eulerAngles.y;
    }

    public void Zoom(float direction)
    {
    }

    [Header("Gamepad")]
    [Range(0, 5)]
    public float analogStickSensitivity = 5.0f;

    [Range(0, 90)]
    public float backwardsCameraAdjustmentAngleDeadzone = 10.0f;

    private CameraInputMode currentCameraInputMode = CameraInputMode.NONE;

    public void ApplyScenicCameraSpin(Vector2 input)
    {
        // override current visual direction based on current camera direction and fully activate scenic camera transition
        scenicDirectionAngle = InterpolatedCameraDirection.x;
        scenicAnglePercentage = 1.0f;

        Vector2 req = target.GetComponent<Movement>().MovementDirectionRequest;
        Vector2 vel = target.GetComponent<Movement>().Velocity;
        float angleOffset = Mathf.Rad2Deg * Mathf.Atan2(-req.x, req.y);

        float backwardsModifier = Mathf.Abs(movementDirection.x - angleOffset) % 360;
        float angle = (backwardsModifier - 180);
        float val = Mathf.Abs(Mathf.Clamp(angle, -(backwardsCameraAdjustmentAngleDeadzone/2), (backwardsCameraAdjustmentAngleDeadzone/2)) / (backwardsCameraAdjustmentAngleDeadzone/2));
        if (req.sqrMagnitude != 0)
        {
            movementDirection.x = Mathf.LerpAngle(movementDirection.x, angleOffset, (1 - velocityBasedAngleCorrection) * val) + 360 % 360;
        }
    
        // apply Y-axis update to movement direction and X-axis update to scenic camera direction
        movementDirection += new Vector2(0, input.y);
        movementDirection.y = Mathf.Clamp(movementDirection.y, cameraAngleYBounds[0], cameraAngleYBounds[1]);

        scenicDirectionAngle += input.x;
    }

    public void ApplyMovementCameraSpin(Vector2 input)
    {
        // override current movement direction based on current camera direction and fully activate scenic camera transition
        movementDirection.x = InterpolatedCameraDirection.x;
        scenicAnglePercentage = 0.0f;
    
        // apply X- and Y-axis update to movement direction
        movementDirection += new Vector2(input.x, input.y);
        movementDirection.y = Mathf.Clamp(movementDirection.y, cameraAngleYBounds[0], cameraAngleYBounds[1]);
    }

    void DetermineCameraState()
    {
        Debug.Log(gameControls.Camera.SetScenicCameraMode);
        if (gameControls.Camera.SetScenicCameraMode.ReadValue<bool>())
        {
            currentCameraInputMode = CameraInputMode.SCENIC;
            return;
        }
        if (gameControls.Camera.SetMovementCameraMode.ReadValue<bool>())
        {
            currentCameraInputMode = CameraInputMode.MOVEMENT;
            return;
        }

        currentCameraInputMode = CameraInputMode.NONE;
        return;
    }

    void Update()
    {
        zoomFactor -= gameControls.Camera.Zoom.ReadValue<float>() * Time.deltaTime * 0.1f;
        zoomFactor = Mathf.Clamp(zoomFactor, 0.0f, 1.0f);

        Debug.Log(currentCameraInputMode);

        DetermineCameraState();

        Vector2 input = gameControls.Camera.Spin.ReadValue<Vector2>();
        switch (currentCameraInputMode)
        {
            case CameraInputMode.NONE:
                scenicAnglePercentage = Mathf.Clamp(scenicAnglePercentage - (scenicAngleSnapbackMaxValue * Time.deltaTime), 0, 1);
                break;
            case CameraInputMode.MOVEMENT:
                ApplyMovementCameraSpin(input);
                break;
            case CameraInputMode.SCENIC:
                ApplyScenicCameraSpin(input);
                break;
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
        Vector3 distance = Vector3.Lerp(zoomTargetOffsetBounds[0], zoomTargetOffsetBounds[1], zoomFactor);

        // determine target position with interpolated Y position
        Vector3 targetPosition = target.position;
        targetPosition.y = currentTargetY;

        transform.position = targetPosition + transform.TransformDirection(distance);
        cameraComponent.fieldOfView = 60;

        // finally look at target
        transform.LookAt(targetPosition + targetOffset);
    }
}
