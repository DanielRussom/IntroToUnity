using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rig;
    public float moveSpeed = 3;
    void Update()
    {
        float xSpeed = GetSpeedOnAxis("Horizontal");
        float zSpeed = GetSpeedOnAxis("Vertical");

        float currentYvelocity = rig.velocity.y;

        rig.velocity = new Vector3(xSpeed, currentYvelocity, zSpeed);
    }

    private float GetSpeedOnAxis(string axis)
    {
        return Input.GetAxisRaw(axis) * moveSpeed;
    }
}
