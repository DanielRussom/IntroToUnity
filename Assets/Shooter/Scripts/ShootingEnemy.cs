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
        Debug.Log("AAA1");
        weapon = GetComponent<Weapon>();
        Debug.Log("AAA2");
        target = FindObjectOfType<PlayerController>().gameObject;
        Debug.Log("AAA3");
        Debug.Log(target);

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
}
