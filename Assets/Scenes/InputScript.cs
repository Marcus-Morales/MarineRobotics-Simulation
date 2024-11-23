using UnityEngine;

public class InputScript : MonoBehaviour
{

    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal") * 10;
        float v = Input.GetAxis("Vertical") * 15;
        
        Vector3 vel = rb.linearVelocity;
        vel.x = h;
        vel.z = v;
        rb.linearVelocity = vel;
    }

}
