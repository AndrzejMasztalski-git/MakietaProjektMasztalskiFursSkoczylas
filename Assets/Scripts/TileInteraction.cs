using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TileInteraction : MonoBehaviour
{
    private BoardManager boardManager;
    private Renderer renderer;
    private Color originalColor;
    public NavMeshSurface navMeshSurface;

    void Start()
    {
        boardManager = FindObjectOfType<BoardManager>();
        renderer = GetComponent<Renderer>();
        originalColor = renderer.material.color;
    }

    void OnMouseEnter()
    {
        boardManager.HighlightTile(gameObject, renderer.material.color);
    }

    void OnMouseDown()
    {
        if (!boardManager.wasPlacedOnce)
        {
            boardManager.PlaceBuildingOnTile(gameObject);
            Debug.Log($"TileInteraction {gameObject.transform.position}");
            boardManager.wasPlacedOnce = true;

            //navMeshSurface.BuildNavMesh();
        }
        else
        {
            Debug.Log("Musisz wybraæ karte!");
        }

    }



    public void ResetTileColor()
    {
        renderer.material.color = originalColor;
    }
}
