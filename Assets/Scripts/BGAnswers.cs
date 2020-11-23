using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGAnswers : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private GameObject TilePrefab;

    // Total amount of tiles
    [SerializeField] private int TileCount = 3;
    // Amount of tiles behind the player
    [SerializeField] private int TilesBehindPlayer = 1;

    // List with all the tiles
    private List<GameObject> Tiles = new List<GameObject>();
    // The length of 1 tile
    private float tileLength;

    private void Awake()
    {
        // Just to be safe :)
        if (TilesBehindPlayer >= TileCount)
            Debug.LogError("TilesBehindPlayer should be smaller than TileCount");
    }

    void Start()
    {
        tileLength = TilePrefab.GetComponent<Renderer>().bounds.size.z;
        SpawnTiles();
    }


    // Spawn the tiles and add them to the list 
    void SpawnTiles()
    {
        for (int i = 0; i < TileCount; i++)
        {
            Vector3 tilePos = Player.position + (i - TilesBehindPlayer) * tileLength * Vector3.forward;
            GameObject tile = Instantiate(TilePrefab, tilePos, Quaternion.identity);

            Tiles.Add(tile);
        }
    }

    private void Update()
    {
        // Check if the tiles should be moved
        if (Player.position.z > Tiles[0].transform.position.z + TilesBehindPlayer * tileLength)
            MoveTile();
    }


    // Move the tile from behind the player to the front
    void MoveTile()
    {
        // Take the first tile
        GameObject tile = Tiles[0];

        // Move it in front of the other tiles
        tile.transform.position = Tiles[TileCount - 1].transform.position + Vector3.forward * tileLength;

        // Put the tile at the end of the list
        Tiles.RemoveAt(0);
        Tiles.Add(tile);
    }
}