using UnityEngine;

public class InputScript : MonoBehaviour
{
    public float moveSpeed;

    float xInput;
    float yInput;

    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        
        if(xInput != 0 || yInput != 0) {
            Debug.Log("Input detected: xInput = " + xInput + ", yInput = " + yInput);
        }

    }

    private void FixedUpdate() {
        rb.AddForce(xInput * moveSpeed, 0, yInput * moveSpeed);
    }

}
