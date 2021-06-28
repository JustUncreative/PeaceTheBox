using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SlimeManager : MonoBehaviour
{
    [SerializeField] private Tilemap map;
    [SerializeField] private TileBase slimeTile;

    [SerializeField] MapManager mapManager;

    private void Update() {
        Vector3 groundTilemapPos = groundTilemap.instance.groundTilemapPosition.position;

        Vector3Int gridPosition = map.WorldToCell(groundTilemapPos);

        TileData data = mapManager.GetTileData(gridPosition);

        SmearTile(gridPosition, data);
    }

    void SmearTile(Vector3Int tilePosition, TileData data){
        if(data != null && data.canSmear){
            map.SetTile(tilePosition, slimeTile);

            //print("Tile set in" + tilePosition);
        }
    }
}
