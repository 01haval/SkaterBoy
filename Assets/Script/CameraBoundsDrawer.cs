using UnityEngine;

[ExecuteAlways]
public class CameraBoundsDrawer : MonoBehaviour
{
    public Color borderColor = Color.green;

    void OnDrawGizmos()
    {
        Camera cam = GetComponent<Camera>();
        if (cam == null || !cam.orthographic) return;

        Gizmos.color = borderColor;

        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        Vector3 topLeft = cam.transform.position + new Vector3(-width / 2, height / 2, 0);
        Vector3 topRight = cam.transform.position + new Vector3(width / 2, height / 2, 0);
        Vector3 bottomRight = cam.transform.position + new Vector3(width / 2, -height / 2, 0);
        Vector3 bottomLeft = cam.transform.position + new Vector3(-width / 2, -height / 2, 0);

        Gizmos.DrawLine(topLeft, topRight);
        Gizmos.DrawLine(topRight, bottomRight);
        Gizmos.DrawLine(bottomRight, bottomLeft);
        Gizmos.DrawLine(bottomLeft, topLeft);
    }
}
