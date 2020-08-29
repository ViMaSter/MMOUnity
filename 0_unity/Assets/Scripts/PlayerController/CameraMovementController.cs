using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovementController : MonoBehaviour
{
    [Header("Movement")]
    public new MMOCamera camera;
    public Movement playerPawnMovement;

    public void OnJump(InputAction.CallbackContext callbackContext)
    {
        playerPawnMovement.QueueJump();
    }

    public void OnMovement(InputAction.CallbackContext callbackContext)
    {
        if (playerPawnMovement == null)
        {
            return;
        }

        Vector2 input = callbackContext.ReadValue<Vector2>();
        
        Vector3 movementRequestInWorldSpace = new Vector3(
            input.x,
            0,
            input.y
        );

        if (movementRequestInWorldSpace.sqrMagnitude != 0)
        {
            Vector3 move = ComputeViewingBasedDirection() * movementRequestInWorldSpace;
            playerPawnMovement.SetMovementRequest(new Vector2(move.x, move.z));
        }
        else
        {
            playerPawnMovement.SetMovementRequest(Vector2.zero);
        }
    }

    #region Movement
    private Quaternion ComputeViewingBasedDirection()
    {
        Vector3 dir = camera.GetComponent<MMOCamera>().GetMovementDirection() * Vector3.forward;
        dir.y = 0;
        return Quaternion.LookRotation(dir.normalized, Vector3.up);
    }
    #endregion
}
