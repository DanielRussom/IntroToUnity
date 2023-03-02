using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float jumpForce;

    [Header("Camera")]
    public float lookSensitivity;
    public float maxLookX;
    public float minLookX;
    private float currentXRotation;

    private Rigidbody body;
    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
        body = GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        Move();

        CamLook();
    }

    private void Move()
    {
        var xMovementSpeed = Input.GetAxis("Horizontal") * moveSpeed;
        var zMovementSpeed = Input.GetAxis("Vertical") * moveSpeed;

        body.velocity = new Vector3(xMovementSpeed, body.velocity.y, zMovementSpeed);
    }

    private void CamLook()
    {
        var y = Input.GetAxis("Mouse X") * lookSensitivity;
        var x = Input.GetAxis("Mouse Y") * lookSensitivity;

        currentXRotation += x;
        currentXRotation = Mathf.Clamp(currentXRotation, minLookX, maxLookX);

        cam.transform.localRotation = Quaternion.Euler(-currentXRotation, 0, 0);

        transform.eulerAngles += Vector3.up * y;
    }
}
