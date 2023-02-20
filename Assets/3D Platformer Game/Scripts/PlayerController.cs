using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody player;
    public float moveSpeed;
    public float jumpForce;

    private bool isGrounded;

    void Update()
    {
        var x = GetAxisVelocity("Horizontal");
        var z = GetAxisVelocity("Vertical");

        player.velocity = new Vector3(x, player.velocity.y, z);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            player.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.GetContact(0).normal == Vector3.up)
        {
            isGrounded = true;
        }
    }

    private float GetAxisVelocity(string axisName)
    {
        return Input.GetAxisRaw(axisName) * moveSpeed;
    }
}
