using UnityEngine;

public class TargettingController : MonoBehaviour
{
    public SingleTargetSelector singleTargetSelector;
    public AreaOfEffectSelector areaOfEffectSelector;

    private void Awake()
    {
        if (singleTargetSelector == null)
        {
            return;
        }
        if (areaOfEffectSelector == null)
        {
            return;
        }
        areaOfEffectSelector.OnAoEPositionSelected += ReenableSingleTargetSelector;
        areaOfEffectSelector.enabled = false;
    }

    private void Update()
    {
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
}
