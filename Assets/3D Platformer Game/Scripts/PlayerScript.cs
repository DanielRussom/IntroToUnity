using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rig;
    public float moveSpeed = 3;
    public float jumpImpulse = 5;
    void Update()
    {
        float xSpeed = GetSpeedOnAxis("Horizontal");
        float zSpeed = GetSpeedOnAxis("Vertical");

        float currentYvelocity = rig.velocity.y;

        rig.velocity = new Vector3(xSpeed, currentYvelocity, zSpeed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rig.AddForce(Vector3.up * jumpImpulse, ForceMode.Impulse);
        }
    
    }

    private float GetSpeedOnAxis(string axis)
    {
        return Input.GetAxisRaw(axis) * moveSpeed;
    }
}
