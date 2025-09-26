using UnityEngine;
using UnityEngine.TextCore.LowLevel;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attack")]
    [SerializeField] private float _attackCoolDown;
    [SerializeField] private int _damage;
    private bool _isAttacking;
    float _coolDownTimer;



    void Awake()
    {
        _attackCoolDown = 1.5f;
        _damage = 1;
        _isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        _coolDownTimer += Time.deltaTime;
        if (_coolDownTimer >= _attackCoolDown && Input.GetMouseButtonDown(0))
        {
            Attack();
        }
        
    }

    public void Attack()
    {
            _isAttacking = true;
        _coolDownTimer = 0f;
            Debug.Log("Ataque");
    }

    void OnTriggerStay(Collider other)
    {
        if (_isAttacking && other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(_damage);
            _isAttacking = false;
        }
    }
}
