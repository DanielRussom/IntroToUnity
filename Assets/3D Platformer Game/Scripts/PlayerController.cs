using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody player;
    public float moveSpeed;
    public float jumpForce;

    void Update()
    {
        var x = GetAxisVelocity("Horizontal");
        var z = GetAxisVelocity("Vertical");

        player.velocity = new Vector3(x, player.velocity.y, z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private float GetAxisVelocity(string axisName)
    {
        return Input.GetAxisRaw(axisName) * moveSpeed;
    }
}
