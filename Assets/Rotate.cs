using UnityEngine;
using UnityEngine.EventSystems;   // ✅ ADD THIS

public class Rotate : MonoBehaviour
{
    [Header("Rotation Settings")]
    public float dragSpeed = 0.2f;

    private Vector2 lastPointerPos;
    private bool isDragging = false;

    // ✅ Store starting rotation for reset
    private Quaternion startRotation;

    void Start()
    {
        startRotation = transform.rotation;
    }

    void Update()
    {
        HandleMouse();
        HandleTouch();
    }

    void HandleMouse()
    {
        // ✅ IMPORTANT: Ignore clicks when pointer is on UI
        if (EventSystem.current != null &&
            EventSystem.current.IsPointerOverGameObject())
            return;

        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            lastPointerPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (!isDragging) return;

        Vector2 delta = (Vector2)Input.mousePosition - lastPointerPos;
        ApplyRotation(delta);
        lastPointerPos = Input.mousePosition;
    }

    void HandleTouch()
    {
        if (Input.touchCount != 1) return;

        // ✅ Ignore UI touches (mobile support)
        if (EventSystem.current != null &&
            EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            return;

        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Moved)
        {
            ApplyRotation(touch.deltaPosition);
        }
    }

    void ApplyRotation(Vector2 delta)
    {
        float rotX = delta.y * dragSpeed;
        float rotY = -delta.x * dragSpeed;

        transform.Rotate(Vector3.right, rotX, Space.World);
        transform.Rotate(Vector3.up, rotY, Space.World);
    }

    // ✅ Call this from UI Button
    public void ResetRotation()
    {
        Debug.Log("RESET WORKED");
        transform.rotation = startRotation;
    }
}