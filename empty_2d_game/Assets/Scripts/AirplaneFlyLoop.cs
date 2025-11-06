using UnityEngine;

public class AirplaneFlyLoop : MonoBehaviour
{
    public float speed = 2f; // movement speed in units per second
    private Vector3 startPosition;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        startPosition = transform.position;
    }

    void Update()
    {
        // Move the airplane up and to the left
        transform.position += new Vector3(-1, 1, 0) * speed * Time.deltaTime;

        // Check if it is completely out of camera view on top or left side
        Vector3 viewportPos = mainCamera.WorldToViewportPoint(transform.position);
        if (viewportPos.x < -0.2f || viewportPos.y > 1.2f)
        {
            // reset to start position to re-enter view
            transform.position = startPosition;
        }
    }
}