using System;
using UnityEngine;

[RequireComponent (typeof(Collider))]

public class UnitDrag : MonoBehaviour
{
    [SerializeField] private LayerMask _draggingLayer;

    private Vector3 _savePosition; 
    private Collider _collider;
    private Vector3 _defaultScale;
    private Vector3 _dragScale = new Vector3(1,1,1);
    private bool _combining;
    public bool Dragging { get; private set; }
    public Unit Unit { get; private set; }

    public event Action<bool> OnDragging;

    private void Start()
    {
        _collider = GetComponent<Collider>();
    }

    private void OnMouseDown()
    {
        _defaultScale = transform.localScale;
        transform.localScale = _dragScale;
        _savePosition = transform.localPosition;
        Dragging = true;
        OnDragging?.Invoke(Dragging);
        _collider.isTrigger = false;
    }

    private void OnMouseUp()
    {
        Dragging = false;
        OnDragging?.Invoke(Dragging);
        _collider.isTrigger = true;

        if (!_combining)
        {
            transform.localPosition = _savePosition;
            transform.localScale = _defaultScale;
        }
    }

    private void FixedUpdate()
    {
        if (Dragging)
            OnDrag();
    }

    public void ChangeCombineValue()
    {
        _combining = true;
    }

    private void OnDrag()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),
           out RaycastHit hit, float.MaxValue, _draggingLayer))
        {
            transform.position = hit.point;
        }
        else
        {
            transform.localPosition = _savePosition;
        }
    }
}
