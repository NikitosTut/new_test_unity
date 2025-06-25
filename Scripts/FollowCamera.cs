using UnityEngine;
using UnityEngine.Tilemaps;

public class FollowCamera : MonoBehaviour {
    public Transform target;
    public float smoothSpeed = 5f;
    public Vector3 offset = new Vector3(0, 0, -10);
    public Tilemap tilemap; // ← сюда перетащишь свою Tilemap

    private float minX, maxX, minY, maxY;
    private float camHalfWidth, camHalfHeight;

    void Start()
    {
        // Размеры камеры
        camHalfHeight = Camera.main.orthographicSize;
        camHalfWidth = camHalfHeight * Camera.main.aspect;

        // Границы карты
        Bounds bounds = tilemap.localBounds;

        minX = bounds.min.x + camHalfWidth;
        maxX = bounds.max.x - camHalfWidth;
        minY = bounds.min.y + camHalfHeight;
        maxY = bounds.max.y - camHalfHeight;
    }

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;

        // Ограничение движения камеры
        float clampedX = Mathf.Clamp(desiredPosition.x, minX, maxX);
        float clampedY = Mathf.Clamp(desiredPosition.y, minY, maxY);
        Vector3 clampedPosition = new Vector3(clampedX, clampedY, desiredPosition.z);

        transform.position = Vector3.Lerp(transform.position, clampedPosition, smoothSpeed * Time.deltaTime);
    }
}
