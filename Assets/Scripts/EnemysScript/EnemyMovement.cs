using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    GameObject _target;
    NavMeshAgent _agent;
    EnemyHealth enemyHealth;
    PlayerHealth playerHealth;
    Animator animator;
    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        enemyHealth = GetComponent<EnemyHealth>();
        animator = GetComponent<Animator>();

        _target = GameObject.FindGameObjectWithTag("Player");

        playerHealth = _target.GetComponent<PlayerHealth>();

    }

    // Update is called once per frame
    void Update()
    {

        if (enemyHealth.Health > 0 && playerHealth.Health > 0)
        {
            if (Vector3.Distance(gameObject.transform.position, _target.transform.position) < 20f && Vector3.Distance(gameObject.transform.position, _target.transform.position) > 2f)
            {
                _agent.SetDestination(_target.transform.position);
            }
        }
        else
        {
            _agent.enabled = false;
            animator.SetBool("IsIdle", true);
        }
    }

}
