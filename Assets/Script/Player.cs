using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                navMeshAgent.SetDestination(hit.point);
            }
        }

        if (navMeshAgent.velocity.magnitude > 0)
        {
            animator.SetBool("moving", true);
            animator.SetFloat("speed", navMeshAgent.velocity.magnitude);
        }
        else
        {
            animator.SetBool("moving", false);
            animator.SetFloat("speed", navMeshAgent.velocity.magnitude);
        }
    }
}
