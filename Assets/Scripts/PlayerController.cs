using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal"); // A/D
        float moveZ = Input.GetAxis("Vertical");   // W/S

        Vector3 movement = new Vector3(moveX, 0f, moveZ);

        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}