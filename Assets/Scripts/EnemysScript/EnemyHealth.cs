using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int _health = 100;

    Animator _anim;

    bool _isAlive = true;

    public int Health
    {
        get { return _health; }
        private set { }
    }
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0 && _isAlive)
        {
            Death();
        }
    }

    void Death()
    {
        _anim.SetTrigger("IsDead");
        _isAlive = false;
        Destroy(gameObject, 2.5f);
    }
}
