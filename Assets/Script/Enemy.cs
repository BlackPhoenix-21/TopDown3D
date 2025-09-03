using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;
    public NavMeshPath path;
    public Spawner spawner;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        bool pathset = agent.SetPath(path);
    }

    void Update()
    {
        if (agent.remainingDistance < 0.5 && path != null)
        {
            agent.SetPath(spawner.EndPoint(path));
        }
    }
}
