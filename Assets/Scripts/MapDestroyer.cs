using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class MapDestroyer : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile wallTile;
    public Tile destructibleTile;
    public GameObject explosionPrefab;
    public GameObject player;

    public void Explode(Vector2 worldPosition)
    {
        Vector3Int originCell = tilemap.WorldToCell(worldPosition);
        ExplodeCell(originCell);
        ExplodeCell(originCell + new Vector3Int(1, 0, 0));
        ExplodeCell(originCell + new Vector3Int(-1, 0, 0));
        ExplodeCell(originCell + new Vector3Int(0, 1, 0));
        ExplodeCell(originCell + new Vector3Int(0, -1, 0));
    }

    void ExplodeCell(Vector3Int cell) 
    {
        Tile tile = tilemap.GetTile<Tile>(cell);

        if (tile == wallTile) 
        {
            return;
        }

        if (tile == destructibleTile)
        {
            tilemap.SetTile(cell, null);
        }

        // create an explosion 
        Vector3 pos = tilemap.GetCellCenterWorld(cell);
        GameObject explosion = Instantiate(explosionPrefab, pos, Quaternion.identity);
        Destroy(explosion, explosion.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length); 
    }
}
