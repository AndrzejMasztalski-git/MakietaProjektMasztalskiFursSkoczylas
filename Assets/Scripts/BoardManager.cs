using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class BoardManager : MonoBehaviour
{
    public int rows = 2;
    public int columns = 2;
    public GameObject whiteTilePrefab;
    public GameObject blackTilePrefab;
    public GameObject hospitalPrefab;
    public GameObject schoolPrefab;
    public GameObject marketPrefab;
    public GameObject fire_stationPrefab;
    public float spacing = 5.0f;
    public Card card;

    private HashSet<int> occupiedTileIds = new HashSet<int>();

    public bool wasPlacedOnce = false;

    private GameObject selectedTile;

    void Start()
    {
        CreateBoard();
        AlignTiles();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Tile"))
                {
                    PlaceBuildingOnTile(hit.transform.gameObject);
                }
            }
        }
    }

    void CreateBoard()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                // Wybierz prefab w zale¿noœci od parzystoœci indeksów
                GameObject tilePrefab = (i + j) % 2 == 0 ? whiteTilePrefab : blackTilePrefab;

                // Oblicz pozycjê dla ka¿dego pola planszy
                Vector3 position = new Vector3(j * spacing, 0, i * spacing);

                // Stwórz nowe pole planszy
                GameObject tile = Instantiate(tilePrefab, position, Quaternion.identity);

                // Ustaw rodzica pola planszy na obiekt planszy
                tile.transform.SetParent(transform);

                // Dodaj komponent odpowiedzialny za interakcje z polem planszy
                tile.AddComponent<TileInteraction>();

                // Ustaw rodzica pola planszy na obiekt planszy
                tile.transform.SetParent(transform);
            }
        }
    }

    void AlignTiles()
    {
        // Pobierz wszystkie obiekty planszy
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");

        // Ustaw wspó³rzêdn¹ Y na 0 dla ka¿dego obiektu planszy
        foreach (GameObject tile in tiles)
        {
            Vector3 position = tile.transform.position;
            position.y = 0;
            tile.transform.position = position;
        }
    }

    public void PlaceBuildingOnTile(GameObject tile)
    {

        if (!wasPlacedOnce)
        {

            Vector3 position = tile.transform.position;
            position.y = 1.0f;

            int tileId = GenerateTileId(position); //unikalny identyfiaktor dla danej p³ytki

            if (!occupiedTileIds.Contains(tileId))
            {
                string chosenCard = card.card1Chosen;
                string symbol = chosenCard.Split('_')[0];

                GameObject buildingPrefab = GetBuildingPrefabForSymbol(symbol);

                if (buildingPrefab != null)
                {
                    Instantiate(buildingPrefab, position, Quaternion.identity);
                    occupiedTileIds.Add(tileId);
                    wasPlacedOnce = true;
                }
                else
                {
                    Debug.LogWarning("Nieobs³ugiwana karta: " + chosenCard);
                }

                if (card.cardsCounter > 0)
                {
                    card.shuffleButton.gameObject.SetActive(true);
                }
            }
            else
            {
                Debug.Log("Ta p³ytka jest ju¿ zajêta!");
                card.ChooseCardsRandomAndSetSprite();
                card.cardsCounter++;
            }
        }
    }

    private GameObject GetBuildingPrefabForSymbol(string symbol)
    {
        switch (symbol)
        {
            case "K":
                return hospitalPrefab;
            case "D":
                return schoolPrefab;
            case "8":
                return marketPrefab;
            case "J":
                return fire_stationPrefab;
            default:
                return null;
        }
    }

    // Metoda do zaznaczenia pola po najechaniu myszk¹
    public void HighlightTile(GameObject tile, Color originalColor)
    {
        // Odznacz poprzednio zaznaczone pole
        if (selectedTile != null)
        {
            TileInteraction tileInteraction = selectedTile.GetComponent<TileInteraction>();
            if (tileInteraction != null)
            {
                tileInteraction.ResetTileColor();
            }
        }

        // Zaznacz nowe pole
        selectedTile = tile;
        TileInteraction selectedTileInteraction = selectedTile.GetComponent<TileInteraction>();
        if (selectedTileInteraction != null)
        {
            selectedTileInteraction.ResetTileColor();
            selectedTile.GetComponent<Renderer>().material.color = Color.yellow;
        }
    }
    private int GenerateTileId(Vector3 position)
    {
        // Prosta funkcja generuj¹ca unikalny identyfikator dla p³ytki na podstawie jej pozycji
        return Mathf.FloorToInt(position.x * 1000) + Mathf.FloorToInt(position.z);
    }
}
