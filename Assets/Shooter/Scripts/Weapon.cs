using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public ObjectPool bulletPool;
    public Transform muzzle;
    public AudioClip shootSound;

    public int maxAmmo;
    public int currentAmmo;
    public bool infiniteAmmo;
    public float bulletSpeed;
    public float fireRate;

    private AudioSource audioSource;
    private float shootTime;
    private bool isPlayer;

    private void Awake()
    {
        if (GetComponent<PlayerController>())
        {
            isPlayer = true;
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void Shoot()
    {
        if (!infiniteAmmo)
        {
            currentAmmo--;
        }
        shootTime = Time.time;

        Console.WriteLine(audioSource.ToString());
        audioSource.PlayOneShot(shootSound);

        var bullet = bulletPool.GetObject();
        bullet.transform.position = muzzle.position;
        bullet.transform.rotation = muzzle.rotation;

        bullet.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;

        if (isPlayer)
        {
            GameUI.instance.UpdateAmmoText(currentAmmo, maxAmmo);
        }
    }

    public bool CanShoot()
    {
        return (currentAmmo > 0 || infiniteAmmo) && Time.time >= shootTime + fireRate;
    }
}
