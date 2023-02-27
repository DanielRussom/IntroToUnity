using UnityEngine;

public class SkiPlayer : MonoBehaviour
{
    public float moveForce = 5;

    public Rigidbody rb;
        // Update is called once per frame
    void FixedUpdate()
    {
        float xInput = Input.GetAxis("Horizontal");
        rb.AddForce(Vector3.right * moveForce * xInput);
    }
}
