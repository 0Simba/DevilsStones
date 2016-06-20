using UnityEngine;
using System.Collections;

public class RoomData {


    public delegate void TileCallback (int x, int y, Tile type);




    public int sizeX;
    public int sizeY;

    public Tile[,] tiles;




    public RoomData (int sizeX, int sizeY) {
        this.sizeX = sizeX;
        this.sizeY = sizeY;

        tiles = new Tile[sizeX, sizeY];

        Fill(Tile.Type.walkable);
    }


    public void Fill (Tile.Type type) {
        ForEachTile((x, y, tile) => {
            tiles[x, y] = new Tile(type);
        });
    }


    public void ForEachTile (TileCallback method) {
        for (int x = 0; x < sizeX; ++x) {
            for (int y = 0; y < sizeY; ++y) {
                method(x, y, tiles[x, y]);
            }
        }
    }


    public Tile RandomTile () {
        int x = Random.Range(0, sizeX);
        int y = Random.Range(0, sizeY);

        return tiles[x, y];
    }
}