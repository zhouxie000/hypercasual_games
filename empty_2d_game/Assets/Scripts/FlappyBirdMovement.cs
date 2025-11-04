using UnityEngine;

public class FlappyBirdMovement : MonoBehaviour
{
    public float amplitude = 0.5f; // how far up and down
    public float frequency = 1f; // how fast

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}