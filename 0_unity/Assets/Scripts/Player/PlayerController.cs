using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public new MMOCamera camera;
    public Movement playerPawn;

    private void Update()
    {
        Vector3 movementRequestInWorldSpace = new Vector3(
            (Input.GetKey(KeyCode.A) ? -1 : 0) + (Input.GetKey(KeyCode.D) ? 1 : 0),
            0,
            (Input.GetKey(KeyCode.W) ? 1 : 0) + (Input.GetKey(KeyCode.S) ? -1 : 0)
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
        Vector3 dir = camera.transform.forward;
        dir.y = 0;
        return Quaternion.LookRotation(dir.normalized, Vector3.up);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(playerPawn.transform.position, playerPawn.transform.position + (ComputeViewingBasedDirection() * Vector3.forward) * 5);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(playerPawn.transform.position, playerPawn.transform.position + (ComputeViewingBasedDirection() * Vector3.right) * 5);
    }
}
