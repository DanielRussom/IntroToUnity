using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;

    public Transform muzzle;

    public int maxAmmo;
    public int currentAmmo;
    public bool infiniteAmmo;
    public float bulletSpeed;
    public float fireRate;
    
    private float shootTime;
    private bool isPlayer;


    private void Awake()
    {
        if (GetComponent<PlayerController>())
        {
            isPlayer = true;
        }
    }

    public void Shoot()
    {
        if (CanShoot())
        {
            Debug.Log("BANG");
        }
    }

    private bool CanShoot()
    {
        return (currentAmmo > 0 || infiniteAmmo) && Time.time >= shootTime + fireRate;
    }

}