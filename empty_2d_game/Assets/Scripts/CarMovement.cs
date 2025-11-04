using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float speed = 5f;
    public float screenLimitX = 10f; // Horizontal limit beyond which the car resets
    public float resetPositionX = -10f; // Position to reset to when car exits view

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        if (transform.position.x > screenLimitX)
        {
            transform.position = new Vector3(resetPositionX, transform.position.y, transform.position.z);
        }
    }
}