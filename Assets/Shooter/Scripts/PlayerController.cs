using System;
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
    private Weapon weapon;

    private void Awake()
    {
        cam = Camera.main;
        body = GetComponent<Rigidbody>();
        weapon = GetComponent<Weapon>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    private void Update()
    {
        Move();

        CamLook();

        if (Input.GetButtonDown("Jump"))
        {
            TryJump();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            weapon.Shoot();
        }
    }



    private void Move()
    {
        var xMovementSpeed = Input.GetAxis("Horizontal") * moveSpeed;
        var zMovementSpeed = Input.GetAxis("Vertical") * moveSpeed;
        var direction = transform.right * xMovementSpeed + transform.forward * zMovementSpeed;
        direction.y = body.velocity.y;

        body.velocity = direction;
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

    private void TryJump()
    {
        var ray = new Ray(transform.position, Vector3.down);
        if(Physics.Raycast(ray, 1.1f))
        {
            body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }
}
