using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public MeshRenderer mesh;

    void OnCollisionEnter(Collision collision)
    {
        mesh.material.color = Color.green;
    }
}