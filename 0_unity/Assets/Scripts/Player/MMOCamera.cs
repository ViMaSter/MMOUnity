﻿using UnityEngine;

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

	[SerializeField]
	Vector2 requestedAngle = new Vector2(0, -45);

	[SerializeField]
	float[] requestedAngleYBounds = {-89, 0};

	float currentTargetY = 0.0f;
	[SerializeField]
	float targetYInterpolation = 0.98f;

	void Awake()
	{
		transform.rotation = target.rotation;
		requestedAngle.x += transform.eulerAngles.y;
	}

	public void Zoom(float direction)
	{
		zoomFactor += direction;
		zoomFactor = Mathf.Clamp(zoomFactor, 0.0f, 1.0f);
	}

    void Update() {
		Zoom(Input.mouseScrollDelta.y * 0.1f);

        if (Input.GetMouseButton(1))
        {
            requestedAngle += new Vector2(Input.GetAxisRaw("CameraX"), Input.GetAxisRaw ("CameraY"));
            requestedAngle.y = Mathf.Clamp(requestedAngle.y, requestedAngleYBounds[0], requestedAngleYBounds[1]);
        }
    }

	void LateUpdate()
	{
		transform.eulerAngles = new Vector3(requestedAngle.y, 180 + requestedAngle.x, 0);

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

    private Vector3 offset;

    private void OnDrawGizmos() {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(target.position, target.position + offset);
    }
}