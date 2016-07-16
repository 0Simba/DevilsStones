using UnityEngine;
using System.Collections;

public class RoomGeography {
    

    /*===================================
    =            Static Part            =
    ===================================*/

    static public RoomCreatorConfig config;

    static public RoomGeography CreateOnce () {
        config = GeneralConfig.instance.roomCreatorConfig;


        int x = config.mapSize.RandomPick();
        int y = config.mapSize.RandomPick();

        RoomGeography roomGeography = new RoomGeography(x, y);

        SetRoomUnwalkable(roomGeography);
        SetRoomObstacles(roomGeography);
        SetDoor(roomGeography);

        return roomGeography;
    }


    static private void SetRoomUnwalkable (RoomGeography roomGeography) {
        int unwalkableNumber = config.unwalkable.RandomPick();

        for (int i = 0; i < 500 && unwalkableNumber > 0; ++i) {
            Tile tile = roomGeography.NotBorderRandomTile();

            if (ApplyTypeIfItsWalkable(tile, Tile.Type.unwalkable)) {
                unwalkableNumber--;
            }
        }
    }


    static private void SetRoomObstacles (RoomGeography roomGeography) {
        int obstacleNumber = config.obstacle.RandomPick();

        for (int i = 0; i < 500 && obstacleNumber > 0; ++i) {
            Tile tile = roomGeography.NotBorderRandomTile();

            if (ApplyTypeIfItsWalkable(tile, Tile.Type.obstacle)) {
                obstacleNumber--;
            }
        }
    }
    

    static private void SetDoor (RoomGeography roomGeography) {
        int y = Random.Range(1, roomGeography.sizeY);
        roomGeography.tiles[roomGeography.sizeX - 1, y].type = Tile.Type.door;
    }


    static private bool ApplyTypeIfItsWalkable (Tile tile, Tile.Type targetType) {
        if (tile.type == Tile.Type.walkable) {
            tile.type = targetType;
            return true;
        }

        return false;
    }




    /*=====================================
    =            Instance Part            =
    =====================================*/
    
    
    public delegate void TileCallback (int x, int y, Tile type);


    public int sizeX;
    public int sizeY;

    public Tile[,] tiles;


    public RoomGeography (int sizeX, int sizeY) {
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


    public Tile NotBorderRandomTile () {
        int x = Random.Range(1, sizeX - 1);
        int y = Random.Range(1, sizeY - 1);

        return tiles[x, y];
    }
}