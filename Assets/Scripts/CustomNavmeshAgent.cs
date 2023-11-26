using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class CustomNavmeshAgent : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject residentPrefab;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // SprawdŸ, czy komponent NavMeshAgent istnieje przed u¿yciem
        if (agent != null)
        {
        }
        else
        {
            Debug.LogError("NavMeshAgent component not found on the object.");
        }
    }

    //IEnumerator Wander()
    //{
    //    while (true)
    //    {
    //        Vector3 randomPoint = GetRandomPointOnNavMesh();

    //       
    //        if (agent.isActiveAndEnabled)
    //        {
    //            agent.SetDestination(randomPoint);
    //        }

    //        
    //        yield return new WaitUntil(() => agent.remainingDistance < 0.1f);
    //    }
    //}

    //Vector3 GetRandomPointOnNavMesh()
    //{
    //    NavMeshHit hit;
    //    Vector3 randomPoint = transform.position + Random.insideUnitSphere * 10f;

    //    if (NavMesh.SamplePosition(randomPoint, out hit, 10f, NavMesh.AllAreas))
    //    {
    //        return hit.position;
    //    }

    //    return transform.position;
    //}

    public void SpawnResident(Transform tileTransform)
    {
        Vector3 spawnPosition = new Vector3(
           tileTransform.position.x + 2,
           tileTransform.position.y + 0.1f,
           tileTransform.position.z - 2
       );
        Instantiate(residentPrefab, spawnPosition, Quaternion.identity);
    }
}