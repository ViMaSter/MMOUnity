using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public new MMOCamera camera;
    public Movement playerPawn;
    
    [Header("Targeting")]
    public SingleTargetSelector singleTargetSelector;
    public AreaOfEffectSelector areaOfEffectSelector;

    private void Awake()
    {
        areaOfEffectSelector.OnAoEPositionSelected += ReenableSingleTargetSelector;
        areaOfEffectSelector.enabled = false;
    }

    private void Update()
    {
        ApplyMovement();
        
        if (Input.GetMouseButtonDown(0))
        {
            if (singleTargetSelector.enabled)
            {
                singleTargetSelector.AttemptSelection();
            }
            if (areaOfEffectSelector.enabled)
            {
                areaOfEffectSelector.AttemptSelection();
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (areaOfEffectSelector.enabled)
            {
                areaOfEffectSelector.CancelSelection();
            }
        }
    }

    #region Movement
    private Quaternion ComputeViewingBasedDirection()
    {
        Vector3 dir = camera.GetComponent<MMOCamera>().GetMovementDirection() * Vector3.forward;
        dir.y = 0;
        return Quaternion.LookRotation(dir.normalized, Vector3.up);
    }

    private void ApplyMovement()
    {
        if (playerPawn == null)
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
            playerPawn.SetMovementRequest(new Vector2(move.x, move.z));
        }
        else
        {
            playerPawn.SetMovementRequest(Vector2.zero);
        }
    }
    #endregion

    #region Targeting
    public void ReenableSingleTargetSelector(Vector3? selectedAoEPosition, RaycastHit[] targets)
    {
        singleTargetSelector.enabled = true;
        areaOfEffectSelector.enabled = false;
        areaOfEffectSelector.OnAoEPositionSelected += ReenableSingleTargetSelector;
    }

    public void RetrieveAoESelectorPosition(float radius, AreaOfEffectSelector.OnAoEPositionSelectedEvent onSelectionEvent)
    {
        areaOfEffectSelector.Radius = radius;
        areaOfEffectSelector.OnAoEPositionSelected += onSelectionEvent;

        areaOfEffectSelector.enabled = true;
        singleTargetSelector.enabled = false;
    }
    #endregion
}
