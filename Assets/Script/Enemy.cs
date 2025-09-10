using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;
    public NavMeshPath path;
    public Spawner spawner;
    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        bool pathset = agent.SetPath(path);
    }

    void Update()
    {
        if (agent.velocity.magnitude > 0)
        {
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }

        if (agent.remainingDistance < 0.5 && path != null)
        {
            agent.SetPath(spawner.EndPoint(path));
        }
    }
}
