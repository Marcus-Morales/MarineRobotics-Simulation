using UnityEngine;

public class InputScript : MonoBehaviour
{
    private Rigidbody rb;

    // Movement and rotation speeds (adjustable in Inspector)
    public float moveSpeed = 10f;        // Speed for forward/backward movement
    public float rotationSpeed = 85;  // Speed for rotation

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Rotation logic
        float rotationInput = Input.GetAxis("Horizontal"); // Left/Right rotation input
        if (rotationInput != 0)
        {
            float rotationAmount = rotationInput * rotationSpeed * Time.deltaTime;
            transform.Rotate(0, rotationAmount, 0); // Rotate the object around the Y-axis
        }

        // Movement logic
        float forwardInput = Input.GetAxis("Vertical"); // Forward/Backward input

        // Move in the local forward direction
        Vector3 movement = transform.forward * forwardInput * moveSpeed;
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z); // Keep the current Y velocity
    }
}
