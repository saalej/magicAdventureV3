using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAI : MonoBehaviour
{
    private string currentState = "IdleState";
    private Transform target;
    [SerializeField] private float chaseRange = 5;
    [SerializeField] private float speed = 3;
    [SerializeField] private float attackRange = 2;
    [SerializeField] private GameObject player;

    [SerializeField] private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        target = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if(currentState == "IdleState")
        {
            if (distance < chaseRange)
            {
                currentState = "ChaseState";
            }
        } else if(currentState == "ChaseState")
        {
            // Reproducir la animación de correr
            animator.SetTrigger("chase");
            animator.SetBool("isAttacking", false);

            if(distance < attackRange)
            {
                currentState = "AttackState";
            }

            // Perseguir al jugador
            if (target.position.x < transform.position.x)
            {
                // Se mueve a la derecha
                transform.Translate(transform.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            else
            {
                // Se mueve a la izquierda
                transform.Translate(-transform.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }

        } else if(currentState == "AttackState")
        {
            animator.SetBool("isAttacking", true);
            if(distance > attackRange)
            {
                currentState = "ChaseState";
            }
        }
    }
}
