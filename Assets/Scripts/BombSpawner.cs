using UnityEngine;
using UnityEngine.Tilemaps;

public class BombSpawner : MonoBehaviour
{
    public Tilemap tilemap;
    public GameObject bombPrefab;
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Vector3Int cell = tilemap.WorldToCell(transform.position);
            Vector3 cellCenterPosition = tilemap.GetCellCenterWorld(cell);

            Instantiate(bombPrefab, cellCenterPosition, Quaternion.identity);
        }
    }
}
