using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] private int damage = 1; // Daño que hace el pincho

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>();
        if (player != null)
        {
            Debug.Log("Player hit by spike, taking damage: " + damage);
            player.TakeDamage(damage);
        }
    }
}
