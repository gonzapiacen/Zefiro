using UnityEngine;
using System;

public class collectibleItem : MonoBehaviour
{
    private ItemEfect effect;

    // Evento que se dispara cuando el item se recoge
    public event Action OnCollected;

    public void SetEffect(ItemEfect newEffect)
    {
        effect = newEffect;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && effect != null)
        {
            effect.Apply(other.gameObject);

            // ✅ Disparar el evento
            OnCollected?.Invoke();

            Destroy(gameObject);
        }
    }
}