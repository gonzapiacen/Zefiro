using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int _health;
    [SerializeField] int _lifes;

    [SerializeField] int _maxHealth = 5;
    [SerializeField] int _maxLifes = 1;

    [SerializeField] private Image heartImage;

    void Start()
    {
        _health = _maxHealth;
        _lifes = _maxLifes;
        UpdateHealthUI();
    }

    public void TakeDamage(int dmg)
    {
        _health -= dmg;

        if (_health <= 0)
        {
            if (_lifes <= 0)
            {
                Death();
            }
            else
            {
                _lifes--;
                _health = _maxHealth; 
            }
        }

        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        if (heartImage != null)
        {
            float porcentaje = (float)_health / _maxHealth;
            heartImage.fillAmount = porcentaje;
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
