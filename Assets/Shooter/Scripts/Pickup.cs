using UnityEngine;

public enum PickupType
{
    Health,
    Ammo
}
public class Pickup : MonoBehaviour
{
    public int value;
    public PickupType type;

    [Header("animation")]
    public float rotateSpeed;
    public float floatSpeed;
    public float floatHeight;

    private Vector3 startPosition;
    private Vector3 offset;

    private void Start()
    {
        startPosition = transform.position;
        offset = new Vector3(0, floatHeight, 0);
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);

        transform.position = Vector3.MoveTowards(transform.position, startPosition + offset, floatSpeed * Time.deltaTime);

        if(transform.position == startPosition + offset)
        {
            offset *= -1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<PlayerController>();
            switch(type)
            {
                case PickupType.Health:
                    player.GiveHealth(value);
                    break;
                case PickupType.Ammo:
                    player.GiveAmmo(value);
                    break;
            }

            Destroy(gameObject);
        }
    }


}
