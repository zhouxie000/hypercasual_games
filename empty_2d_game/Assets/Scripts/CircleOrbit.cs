using UnityEngine;

public class CircleOrbit : MonoBehaviour
{
    public Transform target; // The object to orbit around
    public float orbitSpeed = 50f; // Degrees per second
    public float orbitDistance = 2f; // Distance from the target

    private float angle;

    void Update()
    {
        if (target == null)
            return;

        angle += orbitSpeed * Time.deltaTime;
        float radians = angle * Mathf.Deg2Rad;

        Vector3 offset = new Vector3(Mathf.Cos(radians), Mathf.Sin(radians), 0) * orbitDistance;
        transform.position = target.position + offset;
    }
}