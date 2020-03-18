using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public new Collider collider;
    public new Rigidbody rigidbody;

    public float movementSpeed;
    public float movementFalloff;
    public float jumpForce;

    private float groundedCheckThreshold = 0.1f;

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, collider.bounds.extents.y + groundedCheckThreshold);
    }

    public Vector2 MovementDirectionRequest
    {
        get
        {
            return movementDirectionRequest;
        }
    }
    private Vector2 movementDirectionRequest;
    public void SetMovementRequest(Vector2 direction)
    {
        movementDirectionRequest = direction;
    }

    private void Update()
    {
        if (IsGrounded())
        {
            QueueMove(movementDirectionRequest);

            if (Input.GetButtonDown("Jump"))
            {
                rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            }
        }
        ApplyMovement();
        if (IsGrounded())
        {
            ApplyMovementFalloff();
        }
    }

    public Vector2 Velocity
    {
        get
        {
            return velocity;
        }
    }
    private Vector2 velocity;
    private void QueueMove(Vector2 direction)
    {
        if (direction.sqrMagnitude != 0)
        {
            velocity += direction * movementSpeed;
        }
    }
    private void ApplyMovement()
    {
        transform.rotation = Quaternion.Euler(0, Mathf.Rad2Deg * Mathf.Atan2(velocity.x, velocity.y), 0);
        transform.position += new Vector3(velocity.x, 0, velocity.y) * Time.deltaTime;
    }
    private void ApplyMovementFalloff()
    {
        velocity *= 1 - movementFalloff;
    }
}
