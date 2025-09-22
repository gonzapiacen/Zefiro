using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    GameObject _player;

    [SerializeField] int _enemyDamage = 1;
    [SerializeField] float _coolDownAttack;

    bool _isPlayerInRange;
    float _coolDownTimer;

    EnemyHealth enemyHealth;
    PlayerHealth playerHealth;

    void Awake()
    {
        enemyHealth = GetComponent<EnemyHealth>();

        _player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = _player.GetComponent<PlayerHealth>();
    }
    // Update is called once per frame
    void Update()
    {
        _coolDownTimer += Time.deltaTime;

        if (_coolDownTimer >= _coolDownAttack && _isPlayerInRange && enemyHealth.Health > 0)
        {
            _coolDownTimer = 0f;

            Debug.Log("Attack");
            Attack();
        }
    }

    void Attack()
    {
        playerHealth.TakeDamage(_enemyDamage);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isPlayerInRange = false;
        }
    }
}
