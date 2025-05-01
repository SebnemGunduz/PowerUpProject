using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class TileMapChooser : MonoBehaviour
{
    public Tilemap tileMap;
    public TileBase targetTile; // Aranacak Tile
    public PlaneFSM[] planes;   // Target atanacak objeler

    private List<Vector3> targetPositions = new List<Vector3>();

    void Start()
    {
        FindTilePositions();

        if (targetPositions.Count > 0)
        {
            Debug.Log("Toplam hedef pozisyon: " + targetPositions.Count);

            foreach (PlaneFSM plane in planes)
            {
                Vector3 randomPosition = targetPositions[Random.Range(0, targetPositions.Count)];
                plane.landingTarget = randomPosition;
            }
        }
        else
        {
            Debug.LogWarning("Uygun Tile bulunamadý.");
        }
    }

    void FindTilePositions()
    {
        targetPositions.Clear();

        BoundsInt bounds = tileMap.cellBounds;
        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y < bounds.yMax; y++)
            {
                Vector3Int pos = new Vector3Int(x, y, 0);
                TileBase currentTile = tileMap.GetTile(pos);

                if (currentTile == targetTile)
                {
                    Vector3 worldPos = tileMap.GetCellCenterWorld(pos); // Hücrenin dünya konumunun ortasý
                    targetPositions.Add(worldPos);
                }
            }
        }
    }
}
