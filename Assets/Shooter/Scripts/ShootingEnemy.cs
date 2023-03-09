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
        target = FindObjectOfType<Player>().gameObject;

        InvokeRepeating("UpdatePath", 0.0f, 0.5f);
    }
    
    private void UpdatePath()
    {
        NavMeshPath navMesh = new();
        NavMesh.CalculatePath(transform.position, target.transform.position, NavMesh.AllAreas, navMesh);

        path = navMesh.corners.ToList();
    }


}
