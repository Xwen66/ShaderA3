using UnityEngine;

public class AutomatedCamera : MonoBehaviour
{
    public float speed = 5.0f;
    public Vector3 rotationAxis = Vector3.up;

    void Update()
    {
        transform.RotateAround(Vector3.zero, rotationAxis, speed * Time.deltaTime);
    }
}