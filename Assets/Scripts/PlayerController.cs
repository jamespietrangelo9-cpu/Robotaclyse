using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public bool isMoveable;

    private Rigidbody rb;

    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isMoveable = true;
    }

    void FixedUpdate()
    {
        if (isMoveable == true)
        {
            float moveX = Input.GetAxis("Horizontal"); // A/D
            float moveZ = Input.GetAxis("Vertical");   // W/S

            Vector3 movement = new Vector3(moveX, 0f, moveZ);

            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

            if (movement.magnitude > 0.01f)
            {
                animator.Play("Robert-Move");
            }
            else
            {
                animator.Play("Robert-Idle");
            }
        }
    }
}