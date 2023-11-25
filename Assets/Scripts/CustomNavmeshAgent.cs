using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class CustomNavmeshAgent : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject capsulePrefab;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // SprawdŸ, czy komponent NavMeshAgent istnieje przed u¿yciem
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

            // SprawdŸ, czy agent jest aktywny przed ustawieniem celu
            if (agent.isActiveAndEnabled)
            {
                agent.SetDestination(randomPoint);
            }

            float delay = Random.Range(5f, 10f);
            yield return new WaitForSeconds(delay);

            // Dodaj to wywo³anie, aby postaæ by³a generowana w trakcie ruchu
            SpawnCapsule(transform);
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

    public void SpawnCapsule(Transform tileTransform)
    {
        float capsuleHeight = 2.0f; // Wysokoœæ kapsu³y, dostosuj do swoich potrzeb
        float offset = 0.5f; // Offset od krawêdzi, dostosuj do swoich potrzeb

        Vector3 spawnPosition = new Vector3(
           tileTransform.position.x + offset,
           tileTransform.position.y + capsuleHeight / 2,
           tileTransform.position.z + offset
       );
            Instantiate(capsulePrefab, spawnPosition, Quaternion.identity);
    }
}