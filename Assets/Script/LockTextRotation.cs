using UnityEngine;

public class LockTextRotation : MonoBehaviour
{
    Transform cam;

    void Start()
    {
        cam = Camera.main.transform;
    }

    void LateUpdate()
    {
        if (cam == null) return;

        // Loop through all child texts
        foreach (Transform child in transform)
        {
            // Make each text face camera
            child.forward = cam.forward;
        }
    }
}
