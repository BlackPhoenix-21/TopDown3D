using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    public GameObject[] wayPoints;
    public GameObject endPoint;
    private static List<NavMeshPath> endPath = new();
    private static List<NavMeshPath> paths = new();

    float timerSpawner = 0f;
    int waves = 5;
    int waveSizes = 1;
    public GameObject enemyPrefab;
    public GameObject team;

    void Start()
    {
        for (int i = 0; i < wayPoints.Length; i++)
        {
            NavMeshPath path = new NavMeshPath();
            NavMesh.CalculatePath(transform.position, wayPoints[i].transform.position, NavMesh.AllAreas, path);
            paths.Add(path);
        }

        for (int i = 0; i < wayPoints.Length; i++)
        {
            NavMeshPath path = new NavMeshPath();
            NavMesh.CalculatePath(wayPoints[i].transform.position, endPoint.transform.position, NavMesh.AllAreas, path);
            endPath.Add(path);
        }
        StartCoroutine(Spawning());
    }

    void Update()
    {
        timerSpawner -= Time.deltaTime;
        if (timerSpawner > 0f)
        {
            StartCoroutine(Spawning());
            timerSpawner = 15f;
        }
    }

    IEnumerator Spawning()
    {
        for (int i = 0; i < waves; i++)
        {
            for (int j = 0; j < waveSizes; j++)
            {
                GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity, team.transform);
                enemy.name = $"Golem_{i}_{j}";
                enemy.GetComponent<Enemy>().path = paths[i];
                enemy.GetComponent<Enemy>().spawner = this;
                yield return new WaitForSeconds(0.25f);
            }
            yield return new WaitForSeconds(1f);
        }
    }

    public NavMeshPath EndPoint(NavMeshPath path)
    {
        int i = paths.IndexOf(path);
        return endPath[i];
    }
}
