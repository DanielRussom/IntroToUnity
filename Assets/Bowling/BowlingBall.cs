using UnityEngine;

public class BowlingBall : MonoBehaviour
{
    public Rigidbody body;
    public int forwardForce = 25;
    public float horizontalLimit = 0.5f;

    public void Bowl()
    {
        body.AddForce(new Vector3(0, 0, forwardForce), ForceMode.Impulse);
    }

    public void moveLeft()
    {
        if(transform.position.x > -horizontalLimit)
        {
            transform.position += new Vector3(-0.5f, 0, 0);
        }
    }

    public void moveRight()
    {
        if (transform.position.x < horizontalLimit)
        {
            transform.position += new Vector3(0.5f, 0, 0);
        }
    }
}
