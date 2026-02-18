using UnityEngine;

public class CamPan : MonoBehaviour {
    [Header("Target")]
    public Transform target;

    [Header("Distance")]
    public float dist = 5f;
    public float minDistance = 2f;
    public float maxDistance = 10f;

    [Header("Rotation")]
    public float rotationSpeed = 0.2f;
    public float minYAngle = -20f;
    public float maxYAngle = 80f;

    [Header("Zoom")]
    public float zoomSpeed = 2f;

    private float currentX = 0f;
    private float currentY = 20f;

    private float lastTouchDistance;

    float IniDist;
    float IniMinDist;
    float IniMaxDist;

    void Start() {
        if (target == null) return;

        Vector3 angles = transform.eulerAngles;
        currentX = angles.y;
        currentY = angles.x;

        float IniDist = dist;
        float IniMinDist = minDistance;
        float IniMaxDist = maxDistance;
    }

    public void Reset() {
        dist = IniDist;
        minDistance = IniMinDist;
        maxDistance = IniMaxDist;
    }

    void LateUpdate() {
        if (target == null) return;

        HandleTouchInput();
        HandleMouseInput();

        currentY = Mathf.Clamp(currentY, minYAngle, maxYAngle);
        dist = Mathf.Clamp(dist, minDistance, maxDistance);

        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 direction = rotation * Vector3.forward;

        transform.position = target.position - direction * dist;
        transform.LookAt(target.position);
    }

    void HandleTouchInput() {
        if (Input.touchCount == 1) {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved) {
                currentX += touch.deltaPosition.x * rotationSpeed;
                currentY -= touch.deltaPosition.y * rotationSpeed;
            }
        }

        if (Input.touchCount == 2) {
            Touch t1 = Input.GetTouch(0);
            Touch t2 = Input.GetTouch(1);

            float currentTouchDistance = Vector2.Distance(t1.position, t2.position);

            if (t2.phase == TouchPhase.Began) {
                lastTouchDistance = currentTouchDistance;
            }
            else {
                float delta = currentTouchDistance - lastTouchDistance;
                dist -= delta * zoomSpeed * Time.deltaTime;
                lastTouchDistance = currentTouchDistance;
            }
        }
    }

    void HandleMouseInput() {
        // Rotate with left mouse button
        if (Input.GetMouseButton(0)) {
            currentX += Input.GetAxis("Mouse X") * 200f * rotationSpeed * Time.deltaTime;
            currentY -= Input.GetAxis("Mouse Y") * 200f * rotationSpeed * Time.deltaTime;
        }

        // Zoom with scroll wheel
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f) {
            dist -= scroll * zoomSpeed * 5f;
        }
    }
}
