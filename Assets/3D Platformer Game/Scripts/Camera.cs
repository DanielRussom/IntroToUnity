using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Camera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 5, 5);

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
    }
}
