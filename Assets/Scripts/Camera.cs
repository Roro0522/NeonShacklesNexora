using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void LateUpdate()
    {
        if (target == null) return;
        Vector3 desiredPos = target.position + offset;
        Vector3 smoothed = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
        transform.position = new Vector3(smoothed.x, smoothed.y, transform.position.z);
    }
}
