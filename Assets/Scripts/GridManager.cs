using UnityEngine;
using System.Collections.Generic;

public class GridManager : MonoBehaviour
{
    public GameObject tilePrefab;
    public Vector2[] tilePositions; 
    private List<GameObject> tiles = new List<GameObject>();

    void Start()
    {
        foreach (Vector2 pos in tilePositions)
        {
            GameObject tile = Instantiate(tilePrefab, pos, Quaternion.identity, transform);
            tiles.Add(tile);
        }
    }

    public GameObject GetRandomAvailableTile()
    {
        List<GameObject> availableTiles = new List<GameObject>();

        foreach (var tile in tiles)
        {
            Tile tileScript = tile.GetComponent<Tile>();
            if (tileScript != null && tileScript.IsAvailable())
            {
                availableTiles.Add(tile);
            }
        }

        if (availableTiles.Count == 0) return null;

        GameObject selected = availableTiles[Random.Range(0, availableTiles.Count)];
        selected.GetComponent<Tile>().SetAvailable(false);
        return selected;
    }

    public void ReleaseTile(GameObject tile)
    {
        Tile tileScript = tile.GetComponent<Tile>();
        if (tileScript != null)
        {
            tileScript.SetAvailable(true);
        }
    }
}
