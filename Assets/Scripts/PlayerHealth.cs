using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int _health;

    [SerializeField] int _lifes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _health = 5;
        _lifes = 1;
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
            }
        }
    }

    public void Death()
    {
        SceneManager.LoadScene("Derrota");
    }
}
