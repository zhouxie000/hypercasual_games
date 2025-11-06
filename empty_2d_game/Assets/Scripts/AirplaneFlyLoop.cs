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
        // Calculate the world position of the top-right corner of the camera's view
        Vector3 topRightWorld = mainCamera.ViewportToWorldPoint(new Vector3(1.0f, 1.0f, Mathf.Abs(mainCamera.transform.position.z)));

        // Determine direction from current position towards the top-right corner
        Vector3 direction = (topRightWorld - transform.position).normalized;

        // Move the airplane in that direction
        transform.position += direction * speed * Time.deltaTime;

        // Check if it is completely out of camera view on top or right side
        Vector3 viewportPos = mainCamera.WorldToViewportPoint(transform.position);
        if (viewportPos.x > 1.1f || viewportPos.y > 1.1f)
        {
            // reset to start position to re-enter view and re-fly towards top-right
            transform.position = startPosition;
            // recalculate direction immediately for next frame
            direction = (topRightWorld - transform.position).normalized;
        }
    }
}