using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class ShootingEnemy : MonoBehaviour
{
    [Header("stats")]
    public int currentHP;
    public int maxHP;
    public int scoreToGive;

    [Header("movement")]
    public float moveSpeed;
    public float attackRange;
    public float yPathOffset;

    private List<Vector3> path;
    private Weapon weapon;
    private GameObject target;

    private void Start()
    {
        weapon = GetComponent<Weapon>();
        target = FindObjectOfType<PlayerController>().gameObject;
        currentHP = maxHP;

        InvokeRepeating("UpdatePath", 0.0f, 0.5f);
    }
    
    private void UpdatePath()
    {
        NavMeshPath navMesh = new();
        NavMesh.CalculatePath(transform.position, target.transform.position, NavMesh.AllAreas, navMesh);

        path = navMesh.corners.ToList();
    }

    private void Update()
    {
        var distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance > attackRange)
        {
            ChaseTarget();
            return;
        }

        if(weapon.CanShoot())
        {
            weapon.Shoot();
        }

        var directionToPlayer = (target.transform.position - transform.position).normalized;

        var angleToPlayer = Mathf.Atan2(directionToPlayer.x, directionToPlayer.z) * Mathf.Rad2Deg;

        transform.eulerAngles = angleToPlayer * Vector3.up;
    }

    private void ChaseTarget()
    {
        if(path.Count == 0)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, path[0] + new Vector3(0, yPathOffset, 0), moveSpeed * Time.deltaTime);

        if(transform.position == path[0] + new Vector3(0, yPathOffset, 0))
        {
            path.RemoveAt(0);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if(currentHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
