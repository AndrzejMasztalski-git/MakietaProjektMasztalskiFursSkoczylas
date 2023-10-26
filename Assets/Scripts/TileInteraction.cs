using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInteraction : MonoBehaviour
{
    private BoardManager boardManager;
    private Renderer renderer;
    private Color originalColor;

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
            boardManager.PlaceBallOnTile(gameObject);
            boardManager.wasPlacedOnce = true;

            
        }
        else
        {
            Debug.Log("Karte zosta�a ju� po�o�ona!");
        }

    }



    public void ResetTileColor()
    {
        renderer.material.color = originalColor;
    }
}