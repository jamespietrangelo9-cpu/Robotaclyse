using UnityEngine;

public class SlowUIRotation : MonoBehaviour
{
    public float rotationAngle = 10f;
    public float rotationSpeed = 1f;

    void Update()
    {
        float rotation = Mathf.Sin(Time.time * rotationSpeed) * rotationAngle;

        transform.localRotation = Quaternion.Euler(0, 0, rotation);
    }
}