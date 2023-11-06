using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public bool wasPlacedOnce = false;

    private GameObject selectedTile;

    void Start()
    {
        CreateBoard();
        AlignTiles();
    }

    void Update()
    {

    }

    void CreateBoard()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                // Wybierz prefab w zale�no�ci od parzysto�ci indeks�w
                GameObject tilePrefab = (i + j) % 2 == 0 ? whiteTilePrefab : blackTilePrefab;

                // Oblicz pozycj� dla ka�dego pola planszy
                Vector3 position = new Vector3(j * spacing, 0, i * spacing);

                // Stw�rz nowe pole planszy
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

        // Ustaw wsp�rz�dn� Y na 0 dla ka�dego obiektu planszy
        foreach (GameObject tile in tiles)
        {
            Vector3 position = tile.transform.position;
            position.y = 0;
            tile.transform.position = position;
        }
    }

    public void PlaceBuildingOnTile(GameObject tile)
    {
        Vector3 position = tile.transform.position;
        position.y = 1.0f; // Ustaw wysoko�� budynku

        string chosenCard = card.card1Chosen;

        switch(chosenCard)
        {
            case "K_TREFL_RZUT_P":
                Instantiate(hospitalPrefab, position, Quaternion.identity);
                break;
            case "K_KARO_RZUT_P":
                Instantiate(schoolPrefab, position, Quaternion.identity);
                break;
            case "8_PIK_RZUT_P":
                Instantiate(marketPrefab, position, Quaternion.identity);
                break;
            case "D_KIER_RZUT_P":
                Instantiate(fire_stationPrefab, position, Quaternion.identity);
                break;
            default:
                Debug.LogWarning("Nieobs�ugiwana karta: " + chosenCard);
                break;

        }

        if (card.cardsCounter > 0)
        {
            card.shuffleButton.gameObject.SetActive(true);
        }
    }

    // Metoda do zaznaczenia pola po najechaniu myszk�
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

}
