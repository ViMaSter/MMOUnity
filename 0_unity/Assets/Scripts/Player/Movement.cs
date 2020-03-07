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
            
            if (Input.GetKeyDown(KeyCode.Space))
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
        transform.position += new Vector3(velocity.x, 0, velocity.y) * Time.deltaTime;
    }
    private void ApplyMovementFalloff()
    {
        velocity *= 1 - movementFalloff;
    }
}
