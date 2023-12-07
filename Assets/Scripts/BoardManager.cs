using System.Collections;
using System.Collections.Generic;
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
    public SpawnTreesFountains spawnTreesFountains;
    public CustomNavmeshAgent customNavmeshAgent;
    private HashSet<int> occupiedTileIds = new HashSet<int>();
    public GameObject tile1;
    private GameObject building;

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
                tile1 = Instantiate(tilePrefab, position, Quaternion.identity);

                // Ustaw rodzica pola planszy na obiekt planszy
                tile1.transform.SetParent(transform);

                // Dodaj komponent odpowiedzialny za interakcje z polem planszy
                tile1.AddComponent<TileInteraction>();

                // Ustaw rodzica pola planszy na obiekt planszy
                tile1.transform.SetParent(transform);
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
            position.y = 0;

            int tileId = GenerateTileId(position); //unikalny identyfiaktor dla danej p³ytki

            if (!occupiedTileIds.Contains(tileId))
            {
                string chosenCard = card.card1Chosen;
                string symbol = chosenCard.Split('_')[0];
                

                GameObject buildingPrefab = GetBuildingPrefabForSymbol(symbol);
                Debug.Log(symbol);
                if (buildingPrefab != null)
                {
                    if(symbol == "K")
                    {
                        card.AddBuildingParameters(2, 0, 1);
                    }
                    else if (symbol == "D")
                    {
                        card.AddBuildingParameters(4, 1, 0);
                    }
                    else if (symbol == "8")
                    {
                        card.AddBuildingParameters(0, 1, 1);
                    }
                    else if (symbol == "J")
                    {
                        card.AddBuildingParameters(3, 0, 2);
                    }

                    if (card.scienceValue > 5)
                    {
                        card.satisfactionValue++;
                        card.satisfactionText.text = $"{card.satisfactionValue}";
                    }

                    if (card.cultureValue > 5)
                    {
                        card.satisfactionValue++;
                        card.satisfactionText.text = $"{card.satisfactionValue}";
                    }

                    if (card.houseSpaceValue > 5)
                    {
                        card.satisfactionValue++;
                        card.satisfactionText.text = $"{card.satisfactionValue}";
                    }

                    building = Instantiate(buildingPrefab, position, Quaternion.identity);
                    spawnTreesFountains.SpawnTrees(building.transform.position);
                    spawnTreesFountains.SpawnFountains(building.transform.position);
                    Debug.Log($"{building.transform.position}");
                    customNavmeshAgent.SpawnResident(tile.transform);
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
