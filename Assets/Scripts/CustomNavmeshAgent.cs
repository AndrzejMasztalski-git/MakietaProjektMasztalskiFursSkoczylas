using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class CustomNavmeshAgent : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject miaBikiniPrefab;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Sprawdü, czy komponent NavMeshAgent istnieje przed uøyciem
        if (agent != null)
        {
            StartCoroutine(Wander());
        }
        else
        {
            Debug.LogError("NavMeshAgent component not found on the object.");
        }
    }

    IEnumerator Wander()
    {
        while (true)
        {
            Vector3 randomPoint = GetRandomPointOnNavMesh();

            // Sprawdü, czy agent jest aktywny przed ustawieniem celu
            if (agent.isActiveAndEnabled)
            {
                agent.SetDestination(randomPoint);
            }

            float delay = Random.Range(5f, 10f);
            yield return new WaitForSeconds(delay);

            // Dodaj to wywo≥anie, aby postaÊ by≥a generowana w trakcie ruchu
            SpawnMia(transform);
        }
    }

    Vector3 GetRandomPointOnNavMesh()
    {
        NavMeshHit hit;
        Vector3 randomPoint = transform.position + Random.insideUnitSphere * 10f;

        if (NavMesh.SamplePosition(randomPoint, out hit, 10f, NavMesh.AllAreas))
        {
            return hit.position;
        }

        return transform.position;
    }

    public void SpawnMia(Transform transform)
    {
        var bounds = transform.position;
        var px = bounds.x;
        var py = bounds.y;
        Vector2 pos = new Vector3(px, py);
        Instantiate(miaBikiniPrefab, pos, transform.rotation);
    }
}
