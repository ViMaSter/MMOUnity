using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    public Transform selectedParticleSystem;
    public new Camera camera;
    
    Selectable _currentHoveredSelectable;
    Selectable currentHoveredSelectable
    {
        get
        {
            return _currentHoveredSelectable;
        }
        set
        {
            _currentHoveredSelectable?.OnHoverStateChange(false);
            _currentHoveredSelectable = value;
            _currentHoveredSelectable?.OnHoverStateChange(true);
        }
    }
    
    public delegate void OnSelectionChangedEvent(Selectable newTarget);
    public event OnSelectionChangedEvent OnSelectionChanged;

    Selectable _currentSelectable;
    Selectable currentSelectable
    {
        get
        {
            return _currentSelectable;
        }
        set
        {
            _currentSelectable?.OnStateChange(false);
            _currentSelectable = value;
            OnSelectionChanged(_currentSelectable);
            _currentSelectable?.OnStateChange(true);
        }
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            currentHoveredSelectable = hit.transform.GetComponent<Selectable>();

            if (Input.GetMouseButtonDown(0))
            {
                currentSelectable = currentHoveredSelectable;
            }
        }
    }

    private void LateUpdate()
    {
        UpdateParticleSystem();
    }

    void UpdateParticleSystem()
    {
        if (currentSelectable == null)
        {
            selectedParticleSystem.position = new Vector3(0, -500, 0);
            return;
        }

        selectedParticleSystem.position = currentSelectable.transform.position - Vector3.up * currentSelectable.GetComponent<Collider>().bounds.extents.y;
    }
}
