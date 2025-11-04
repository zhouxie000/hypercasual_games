using UnityEngine;

public class Route66CarMovement : MonoBehaviour
{
    public float speed = 5f;
    public float leftBoundary = -10f;
    public float rightBoundary = 10f;

    void Update()
    {
        // Move the car to the right
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        // Check if the car has passed the right boundary
        if (transform.position.x > rightBoundary)
        {
            // Reset to the left boundary
            Vector3 newPos = transform.position;
            newPos.x = leftBoundary;
            transform.position = newPos;
        }
    }
}