using UnityEngine;

public class CameraMovementController : MonoBehaviour
{
    [Header("Movement")]
    public new MMOCamera camera;
    public Movement playerPawnMovement;

    private void Update()
    {
        if (playerPawnMovement == null)
        {
            return;
        }
        
        Vector3 movementRequestInWorldSpace = new Vector3(
            Input.GetAxis("MovementX"),
            0,
            Input.GetAxis("MovementY")
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
