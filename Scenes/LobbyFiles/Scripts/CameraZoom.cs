using UnityEngine;

public class CameraZoom : MonoBehaviour {
    public Transform target;               // Куда приблизить (позиция UI или персонажа)
    public float targetSize = 3f;          // Какой зум при приближении
    public float zoomSpeed = 2f;           // Скорость приближения
    public float moveSpeed = 5f;           // Скорость движения

    private float defaultSize;
    private Vector3 defaultPos;

    private Camera cam;
    private bool zoomIn = false;

    void Start()
    {
        cam = Camera.main;
        defaultSize = cam.orthographicSize;
        defaultPos = cam.transform.position;
    }

    void Update()
    {
        if (zoomIn)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetSize, Time.deltaTime * zoomSpeed);
            cam.transform.position = Vector3.Lerp(cam.transform.position, new Vector3(target.position.x, target.position.y, cam.transform.position.z), Time.deltaTime * moveSpeed);
        }
        else
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, defaultSize, Time.deltaTime * zoomSpeed);
            cam.transform.position = Vector3.Lerp(cam.transform.position, defaultPos, Time.deltaTime * moveSpeed);
        }
    }

    public void ZoomToTarget(bool zoom)
    {
        zoomIn = zoom;
    }
}
