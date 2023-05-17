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
             

        }
    }
}
