using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public new MMOCamera camera;
    public Movement playerPawn;

    private void Update()
    {
        Vector3 movementRequestInWorldSpace = new Vector3(
            Input.GetAxis("MovementX"),
            0,
            Input.GetAxis("MovementY")
        );

        if (movementRequestInWorldSpace.sqrMagnitude != 0)
        {
            Vector3 move = ComputeViewingBasedDirection() * movementRequestInWorldSpace;
            playerPawn.SetMovementRequest(new Vector2(move.x, move.z));
        }
        else
        {
            playerPawn.SetMovementRequest(Vector2.zero);
        }
    }

    private Quaternion ComputeViewingBasedDirection()
    {
        Vector3 dir = camera.GetComponent<MMOCamera>().GetMovementDirection() * Vector3.forward;
        dir.y = 0;
        return Quaternion.LookRotation(dir.normalized, Vector3.up);
    }
}
