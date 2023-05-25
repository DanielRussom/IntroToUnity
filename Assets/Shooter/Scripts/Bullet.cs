using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float lifetime;
    private float shootTime;
    public GameObject particleEfffect;

    private void OnEnable()
    {
        shootTime = Time.time;

    }

    private void Update()
    {
        if(Time.time - shootTime >= lifetime)
        { 
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var obj = Instantiate(particleEfffect, transform.position, Quaternion.identity);
        Destroy(obj, 0.5f);
        Debug.Log("start");
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().TakeDamage(damage);
        }
        else if (other.CompareTag("Enemy"))
        {
            other.GetComponent<ShootingEnemy>().TakeDamage(damage);
        }
        gameObject.SetActive(false);
        Debug.Log("end");
    }


}
