using System;
using System.Transactions;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("stats")]
    public int currentHP;
    public int maxHP;

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

    private void Start()
    {
        GameUI.instance.UpdateHealthBar(currentHP, maxHP);
        GameUI.instance.UpdateScoreText(0);
        GameUI.instance.UpdateAmmoText(weapon.currentAmmo, weapon.maxAmmo);
    }
    private void Awake()
    {
        cam = Camera.main;
        body = GetComponent<Rigidbody>();
        weapon = GetComponent<Weapon>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    private void Update()
    {
        if (GameManager.instance.isGamePaused) 
        {
            return;
        }

        Move();

        CamLook();

        if (Input.GetButtonDown("Jump"))
        {
            TryJump();
        }

        if (Input.GetButtonDown("Fire1") && weapon.CanShoot())
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

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            Die();
        }
        GameUI.instance.UpdateHealthBar(currentHP, maxHP);
    }

    private void Die()
    {
        GameManager.instance.LoseGame();
    }

    internal void GiveHealth(int value)
    {
        currentHP += value;
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
        GameUI.instance.UpdateHealthBar(currentHP, maxHP);
    }

    internal void GiveAmmo(int value)
    {
        weapon.currentAmmo = Mathf.Clamp(weapon.currentAmmo+value, 0, weapon.maxAmmo);
        GameUI.instance.UpdateAmmoText(weapon.currentAmmo, weapon.maxAmmo);
    }
}
