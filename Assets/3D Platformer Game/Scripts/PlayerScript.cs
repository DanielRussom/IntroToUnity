using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rig;
    
    public float moveSpeed = 3;
    public float jumpImpulse = 5;
    private bool isGrounded;
    void Update()
    {
        float xSpeed = GetSpeedOnAxis("Horizontal");
        float zSpeed = GetSpeedOnAxis("Vertical");

        float currentYvelocity = rig.velocity.y;

        rig.velocity = new Vector3(xSpeed, currentYvelocity, zSpeed);

        if (xSpeed != 0 || zSpeed != 0)
        {
            transform.forward = new Vector3(xSpeed, 0, zSpeed);
        }
        


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rig.AddForce(Vector3.up * jumpImpulse, ForceMode.Impulse);
            isGrounded = false;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.GetContact(0).normal == Vector3.up)
        {
            isGrounded = true;
        }
    }

    private float GetSpeedOnAxis(string axis)
    {
        return Input.GetAxisRaw(axis) * moveSpeed;
    }
}
