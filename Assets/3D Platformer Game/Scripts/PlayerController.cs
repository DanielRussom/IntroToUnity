using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody player;
    public float moveSpeed;

    void Update()
    {
        var x = GetAxisVelocity("Horizontal");
        var z = GetAxisVelocity("Vertical");

        player.velocity = new Vector3(x, player.velocity.y, z);
    }

    private float GetAxisVelocity(string axisName)
    {
        return Input.GetAxisRaw(axisName) * moveSpeed;
    }
}
