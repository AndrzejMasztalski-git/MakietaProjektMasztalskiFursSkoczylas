using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTreesFountains : MonoBehaviour
{

    public GameObject treePrefab;
    public GameObject fountainPrefab;
    public void SpawnTrees(Transform transform)
    {
        var bounds = transform.position;
        var px = bounds.x;
        var py = bounds.y;
        Vector2 pos = new Vector3(px, py);
        Instantiate(treePrefab, pos, transform.rotation);
    }

    public void SpawnFountains(Transform transform)
    {
        var bounds = transform.position;
        var px = bounds.x;
        var py = bounds.y;
        Vector2 pos = new Vector3(px, py);
        Instantiate(fountainPrefab, pos, transform.rotation);
    }
}
