using System.Linq;
using UnityEngine;

public class AreaOfEffectSelector : MonoBehaviour
{
    public GameObject validAoEIndicator;
    public GameObject invalidAoEIndicator;
    public new Camera camera;

    public Vector3 offsetFromSurface = new Vector3(0, 0.1f, 0);

    
    public delegate void OnAoEPositionSelectedEvent(Vector3? newTarget);
    public event OnAoEPositionSelectedEvent OnAoEPositionSelected;

    private int validAoELayer;
    private int invalidAoELayer;
    
    public float Radius = 1f;

    private void Awake()
    {
        validAoELayer = LayerMask.NameToLayer("ValidAoE");
        invalidAoELayer = LayerMask.NameToLayer("InvalidAoE");
    }

    private void OnEnable()
    {
        validAoEIndicator.transform.localScale = (new Vector3(1, 0, 1) * (Radius*2)) + new Vector3(0, 0.001f, 0);
        invalidAoEIndicator.transform.localScale = (new Vector3(1, 0, 1) * (Radius*2)) + new Vector3(0, 0.001f, 0);
    }

    public void CancelSelection()
    {
        SubmitAndReset(null);
    }

    private void SubmitAndReset(Vector3? newTarget)
    {
        var events = OnAoEPositionSelected;
        OnAoEPositionSelected = null;
        events(newTarget);
        
        validAoEIndicator.transform.localScale = Vector3.zero;
        invalidAoEIndicator.transform.localScale = Vector3.zero;
        validAoEIndicator.transform.position = Vector3.one * -5000;
        invalidAoEIndicator.transform.position = Vector3.one * -5000;
    }

    public void AttemptSelection()
    {
        RaycastHit mouseHit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out mouseHit, Mathf.Infinity, 1 << validAoELayer | 1 << invalidAoELayer))
        {
            if (mouseHit.transform.gameObject.layer == validAoELayer)
            {
                SubmitAndReset(mouseHit.point);
            }
        }
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << validAoELayer | 1 << invalidAoELayer))
        {
            bool isValidAoE = hit.transform.gameObject.layer == validAoELayer;

            validAoEIndicator.gameObject.SetActive(isValidAoE);
            invalidAoEIndicator.gameObject.SetActive(!isValidAoE);

            (isValidAoE ? validAoEIndicator : invalidAoEIndicator).transform.position = hit.point + Vector3.Project(offsetFromSurface, hit.normal);
            (isValidAoE ? validAoEIndicator : invalidAoEIndicator).transform.rotation = Quaternion.LookRotation(Vector3.forward, hit.normal);

        }
    }
}
