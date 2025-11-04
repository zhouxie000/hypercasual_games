using UnityEngine;

public class FlappyBirdMovement : MonoBehaviour
{
    public float horizontalSpeed = 3f;
    public float amplitude = 0.5f; // up and down distance
    public float frequency = 1f; // up and down speed
    public float screenLimitX = 10f; // Horizontal limit
    public float resetPositionX = -10f; // Reset X position

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Horizontal movement
        transform.Translate(Vector3.right * horizontalSpeed * Time.deltaTime);

        // Vertical oscillation
        float newY = startPos.y + Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // Loop back horizontally when off screen
        if (transform.position.x > screenLimitX)
        {
            transform.position = new Vector3(resetPositionX, transform.position.y, transform.position.z);
        }
    }
}