using UnityEngine;

public class AirplaneFlyLoop : MonoBehaviour
{
    public float speed = 4f; // movement speed in units per second
    private Vector3 startPosition;
    private Camera mainCamera;
    private int direction = 1; // 1 means right, -1 means left

    void Start()
    {
        mainCamera = Camera.main;
        startPosition = transform.position;

    }

    void Update()
    {
        // Move airplane horizontally based on direction
        transform.position += new Vector3(direction, 0, 0) * speed * Time.deltaTime;

        // Get airplane position in viewport coordinates (0 to 1 is inside camera view)
        Vector3 viewportPos = mainCamera.WorldToViewportPoint(transform.position);

        // Check if airplane reached left boundary
        if (viewportPos.x <= 0f)
        {
            direction = 1; // change direction to right

            // Flip sprite vertically
            Vector3 scale = transform.localScale;
            scale.y = Mathf.Abs(scale.y);
            transform.localScale = scale;
        }

        // Check if airplane reached right boundary
        if (viewportPos.x >= 1f)
        {
            direction = -1; // change direction to left

            // Flip sprite vertically
            Vector3 scale = transform.localScale;
            scale.y = -Mathf.Abs(scale.y);
            transform.localScale = scale;
        }
    }
}