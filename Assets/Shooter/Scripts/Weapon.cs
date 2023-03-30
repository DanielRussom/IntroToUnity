using UnityEngine;

public class Weapon : MonoBehaviour
{
    public ObjectPool bulletPool;

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
        currentAmmo--;
        shootTime = Time.time;

        var bullet = bulletPool.GetObject();
        bullet.transform.position = muzzle.position;
        bullet.transform.rotation = muzzle.rotation;

        bullet.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;
    }

    public bool CanShoot()
    {
        return (currentAmmo > 0 || infiniteAmmo) && Time.time >= shootTime + fireRate;
    }

}
