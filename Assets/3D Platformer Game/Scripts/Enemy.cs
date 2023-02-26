using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Vector3 moveOffset;

    private Vector3 targetPosition;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (transform.position != targetPosition)
        {
            return;
        }

        if (targetPosition == startPosition)
        {
            targetPosition = startPosition + moveOffset;
        }
        else 
        {
            targetPosition = startPosition;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) 
        {
            other.GetComponent<PlayerScript>().GameOver();
        }
    }
}
