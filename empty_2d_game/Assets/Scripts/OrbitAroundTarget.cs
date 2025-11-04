using UnityEngine;

public class OrbitAroundTarget : MonoBehaviour
{
    public Transform target; // The object to orbit around
    public float orbitSpeed = 30f; // Degrees per second
    public float orbitDistance = 2f; // Distance from target

    private float angle;

    void Update()
    {
        if (target == null) return;

        angle += orbitSpeed * Time.deltaTime;
        float rad = angle * Mathf.Deg2Rad;
        Vector3 offset = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0) * orbitDistance;
        transform.position = target.position + offset;
    }
}